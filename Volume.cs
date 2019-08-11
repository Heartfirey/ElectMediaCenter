using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAudioApi;

namespace Volume
{
    public class VolumeControl
    {
        private static VolumeControl _VolumeControl;
        private MMDevice device;
        public event AudioNotificationDelegate OnAudioNotification;
        public bool InitializeSucceed;

        public static VolumeControl Instance
        {
            get
            {
                if (_VolumeControl == null)
                    _VolumeControl = new VolumeControl();
                return _VolumeControl;
            }
        }

        private VolumeControl()
        {
            MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
            try
            {
                device = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
                device.AudioEndpointVolume.OnVolumeNotification += new AudioEndpointVolumeNotificationDelegate(AudioEndpointVolume_OnVolumeNotification);
                InitializeSucceed = true;
            }
            catch
            {
                InitializeSucceed = false;
            }
        }

        private void AudioEndpointVolume_OnVolumeNotification(AudioVolumeNotificationData data)
        {
            if (InitializeSucceed && this.OnAudioNotification != null)
            {
                this.OnAudioNotification(null, new AudioNotificationEventArgs() { MasterVolume = data.MasterVolume * 100, Muted = data.Muted });
            }
        }

        public double MasterVolume
        {
            get { return InitializeSucceed ? device.AudioEndpointVolume.MasterVolumeLevelScalar * 100 : 0; }
            set
            {
                if (InitializeSucceed)
                {
                    device.AudioEndpointVolume.MasterVolumeLevelScalar = (float)(value / 100.0f);
                    if (this.IsMute)
                        this.IsMute = false;
                }
            }
        }

        public bool IsMute
        {
            get { return InitializeSucceed ? device.AudioEndpointVolume.Mute : true; }
            set { if (InitializeSucceed) device.AudioEndpointVolume.Mute = value; }
        }

        public double[] AudioMeterInformation
        {
            get
            {
                if (InitializeSucceed)
                {
                    try
                    {
                        return new double[3]{
                        device.AudioMeterInformation.MasterPeakValue * 100.00,
                        device.AudioMeterInformation.PeakValues[0] * 100,
                        device.AudioMeterInformation.PeakValues[1] * 100
                    };
                    }
                    catch
                    {
                        return new double[3] { 0, 0, 0 };
                    }
                }
                else
                    return new double[3] { 0, 0, 0 };
            }
        }
    }

    public delegate void AudioNotificationDelegate(object sender, AudioNotificationEventArgs e);

    public class AudioNotificationEventArgs : EventArgs
    {
        public double MasterVolume { get; set; }
        public bool Muted { get; set; }
    }
}
