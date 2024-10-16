using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace LibCamera
{
    public partial class LibCameraModel
    {
        private ushort? _verbose;
        private string? _config;
        private double? _brightness;
        private double? _contrast;
        private double? _saturation;
        private double? _sharpness;

        /// <summary>
        /// It is a camera-id.
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad camera id. Use unsigned int value.")]
        public uint? Camera { get; set; }

        /// <summary>
        /// Set verbosity level. Level 0 is no output, 1 is default, 2 is verbose.
        /// </summary>
        [Range(0, 2, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Unknown verbose level. Use only 0, 1 or 2 value.")]
        public ushort? Verbose
        {
            get => _verbose;
            set
            {
                if (value is not null && (value < 0 || value > 2)) InvalidValueActionEvent?.Invoke("Verbose");
                _verbose = value;
            }
        }

        /// <summary>
        /// Read the options from a file. If no filename is specified, default to config.txt. In case of duplicate options, the ones provided on the command line
        /// will be used. Note that the config file must only contain the long form options.
        /// If set "-" to Config local _config will "config.txt".
        /// </summary>
        public string? Config
        {
            get => _config;
            set
            {
                if (value is not null && value == "-") _config = "config.txt";
                _config = value;
            }
        }

        /// <summary>
        /// Sets the information string on the titlebar. Available values:
        /// <list type="bullet">
        ///<item>%frame(frame number)</item>
        ///<item>%fps(framerate)</item>
        ///<item>%exp(shutter speed)</item>
        ///<item>%ag(analogue gain)</item>
        ///<item>%dg(digital gain)</item>
        ///<item>%rg(red colour gain)</item>
        ///<item>%bg(blue colour gain)</item>
        ///<item>%focus(focus FoM value)</item>
        ///<item>%aelock(AE locked status)</item>
        ///<item>%lp(lens position, if known)</item>
        ///<item>%afstate(AF state, if supported)</item>
        ///</list>
        /// default: "#%frame (%fps fps) exp %exp ag %ag dg %dg".
        /// </summary>
        public string? InfoText { get; set; }

        /// <summary>
        /// Set the output image width (0 = use default value).
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad width. Use unsigned int value.")]
        public uint? Width { get; set; }

        /// <summary>
        /// Set the output image height (0 = use default value).
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad height. Use unsigned int value.")]
        public uint? Height { get; set; }

        /// <summary>
        /// Time for which program runs. If no units are provided default to ms.
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad timeout value. Use unsigned int value.")]
        public uint? TimeOut { get; set; }

        /// <summary>
        /// Set the output file name.
        /// </summary>
        public string? Output { get; set; }

        /// <summary>
        /// Set the file name for configuring the post-processing.
        /// </summary>
        public string? PostProcessFile { get; set; }

        /// <summary>
        /// Set a custom location for the post-processing library .so files.
        /// </summary>
        public string? PostProcessLibs { get; set; }

        /// <summary>
        /// Do not show a preview window.
        /// </summary>
        public bool? NoPreview { get; set; }

        /// <summary>
        /// Set the preview window dimensions, given as x,y,width,height e.g. 0,0,640,480.
        /// </summary>
        public PreviewModel? Preview { get; set; }

        /// <summary>
        /// Use a fullscreen preview window.
        /// </summary>
        public bool? Fullscreen { get; set; }

        /// <summary>
        /// Use Qt-based preview window (WARNING: causes heavy CPU load, fullscreen not supported).
        /// </summary>
        public bool? QTPreview { get; set; }

        /// <summary>
        /// Request a horizontal flip transform.
        /// </summary>
        public bool? HFlip { get; set; }

        /// <summary>
        /// Request a vertical flip transform.
        /// </summary>
        public bool? VFlip { get; set; }

        /// <summary>
        /// Request an image rotation, 0 or 180. Отзеркаливание изображения, 0 (false) - не зеркалит, 180 (true) - зеркалит.
        /// </summary>
        public bool? Rotation { get; set; }

        /// <summary>
        /// Set region of interest (digital zoom) e.g. 0.25, 0.25, 0.5, 0.5.
        /// </summary>
        public ROIModel? ROI { get; set; }

        /// <summary>
        /// Set a fixed shutter speed. If no units are provided default to us.
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad Shutter value. Use unsigned int value.")]
        public uint? Shutter { get; set; }

        /// <summary>
        /// Set a fixed gain value.
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad Gain value. Use unsigned int value.")]
        public uint? Gain { get; set; }

        /// <summary>
        /// Set the metering mode (centre, spot, average, custom).
        /// </summary>
        [Range(0, 3, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad enum value set 0-3.")]
        public MeteringEnum? Metering { get; set; }

        /// <summary>
        /// Set the exposure mode (normal, sport).
        /// </summary>
        [Range(0, 1, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad enum value set 0 or 1.")]
        public ExposureEnum? Exposure { get; set; }

        /// <summary>
        /// Set the EV exposure compensation, where 0 = no change.
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad EV value. Use unsigned int value.")]
        public uint? EV { get; set; }

        /// <summary>
        /// Set the AWB mode (auto, incandescent, tungsten, fluorescent, indoor, daylight, cloudy, custom).
        /// </summary>
        [Range(0, 7, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad enum value set 0-7.")]
        public AWBEnum? AWB { get; set; }

        /// <summary>
        /// Set explict red and blue gains (disable the automatic AWB algorithm).
        /// </summary>
        public AWBGainsModel? AWBGains { get; set; }

        /// <summary>
        /// Flush output data as soon as possible.
        /// </summary>
        public bool? Flush { get; set; }

        /// <summary>
        /// When writing multiple output files, reset the counter when it reaches this number.
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad Wrap value. Use unsigned int value.")]
        public uint? Wrap { get; set; }

        /// <summary>
        /// Adjust the brightness of the output images, in the range -1.0 to 1.0.
        /// </summary>
        [Range(-1.0, 1.0, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Invalid value for brightness. Correct value is [-1.0, 1.0].")]
        public double? Brightness
        {
            get => _brightness;
            set
            {
                if (value is not null && ((double)value < -1.0 || (double)value > 1.0)) InvalidValueActionEvent?.Invoke("Brightness");
                _brightness = value;
            }
        }

        /// <summary>
        /// Adjust the contrast of the output image, where 1.0 = normal contrast.
        /// </summary>
        [Range(0.0, 1.0, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Invalid value for contrast. Correct value is [0.0, 1.0].")]
        public double? Contrast
        {
            get => _contrast;
            set
            {
                if (value is not null && ((double)value < 0.0 || (double)value > 1.0)) InvalidValueActionEvent?.Invoke("Contrast");
                _contrast = value;
            }
        }

        /// <summary>
        /// Adjust the colour saturation of the output, where 1.0 = normal and 0.0 = greyscale.
        /// </summary>
        [Range(0.0, 1.0, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Invalid value for saturation. Correct value is [0.0, 1.0].")]
        public double? Saturation
        {
            get => _saturation;
            set
            {
                if (value is not null && ((double)value < 0.0 || (double)value > 1.0)) InvalidValueActionEvent?.Invoke("Saturation");
                _saturation = value;
            }
        }

        /// <summary>
        /// Adjust the sharpness of the output image, where 1.0 = normal sharpening.
        /// </summary>
        [Range(0.0, 1.0, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Invalid value for sharpness. Correct value is [0.0, 1.0].")]
        public double? Sharpness
        {
            get => _sharpness;
            set
            {
                if (value is not null && ((double)value < 0.0 || (double)value > 1.0)) InvalidValueActionEvent?.Invoke("Sharpness");
                _sharpness = value;
            }
        }

        /// <summary>
        /// Set the fixed framerate for preview and video modes.
        /// </summary>        
        public int? Framerate { get; set; }

        /// <summary>
        /// Sets the Denoise operating mode: auto, off, cdn_off, cdn_fast, cdn_hq.
        /// </summary>
        [Range(0, 4, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad enum value set 0-4.")]
        public DenoiseEnum? Denoise { get; set; }

        /// <summary>
        /// Width of viewfinder frames from the camera (distinct from the preview window size).
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad ViewFinderWidth value. Use unsigned int value.")]
        public uint? ViewFinderWidth { get; set; }

        /// <summary>
        /// Height of viewfinder frames from the camera (distinct from the preview window size).
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad ViewFinderHeight value. Use unsigned int value.")]
        public uint? ViewFinderHeight { get; set; }

        /// <summary>
        /// Name of camera tuning file to use, omit this option for libcamera default behaviour.
        /// </summary>
        public string? TuningFile { get; set; }

        /// <summary>
        /// Width of low resolution frames (use 0 to omit low resolution stream).
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad LoresWidth value. Use unsigned int value.")]
        public uint? LoresWidth { get; set; }

        /// <summary>
        /// Height of low resolution frames (use 0 to omit low resolution stream).
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad LoresHeight value. Use unsigned int value.")]
        public uint? LoresHeight { get; set; }

        /// <summary>
        /// Camera mode as W:H:bit-depth:packing, where packing is P (packed) or U (unpacked).
        /// </summary>
        public ModeModel? Mode { get; set; }

        /// <summary>
        /// Camera mode for preview as W:H:bit-depth:packing, where packing is P (packed) or U (unpacked).
        /// </summary>
        public ModeModel? ViewFinderMode { get; set; }

        /// <summary>
        /// Number of in-flight requests (and buffers) configured for video, raw, and still.
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad BufferCount value. Use unsigned int value.")]
        public uint? BufferCount { get; set; }

        /// <summary>
        /// Number of in-flight requests (and buffers) configured for preview window.
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad ViewFinderBufferCount value. Use unsigned int value.")]
        public uint? ViewFinderBufferCount { get; set; }

        /// <summary>
        /// Disable requesting of a RAW stream. Will override any manual mode reqest the mode choice when setting framerate.
        /// </summary>
        public bool? NoRaw { get; set; }

        /// <summary>
        /// Control to set the mode of the AF (autofocus) algorithm.(manual, auto, continuous).
        /// </summary>
        [Range(0, 2, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad enum value set 0-2.")]
        public AutoFocusModeEnum? AutoFocusMode { get; set; }

        /// <summary>
        /// Set the range of focus distances that is scanned.(normal, macro, full).
        /// </summary>
        [Range(0, 2, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad enum value set 0-2.")]
        public AutoFocusRangeEnum? AutoFocusRange { get; set; }

        /// <summary>
        /// Control that determines whether the AF algorithm is to move the lens as quickly as possible or more steadily. (normal, fast).
        /// </summary>
        [Range(0, 1, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad enum value set 0 or 1.")]
        public AutoFocusSpeedEnum? AutoFocusSpeed { get; set; }

        /// <summary>
        /// Sets AfMetering to  AfMeteringWindows an set region used, e.g. 0.25,0.25,0.5,0.5.
        /// </summary>
        public ROIModel? AutoFocusWindow { get; set; }

        /// <summary>
        /// Set the lens to a particular focus position, expressed as a reciprocal distance (0 moves the lens to infinity), or "default" for the hyperfocal distance.
        /// </summary>
        [RegularExpression(@"(0)|(default)", ErrorMessage = "Set 0 or default.")]
        public string? LensPosition { get; set; }

        /// <summary>
        /// Enable High Dynamic Range, where supported. Available values are "off", "auto", "sensor" for sensor HDR(e.g. for Camera Module 3), "single-exp" 
        /// for PiSP based single exposure multiframe HDR.
        /// </summary>
        [Range(0, 3, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad enum value set 0-3.")]
        public HDREnum? HDR { get; set; }

        /// <summary>
        /// Save captured image metadata to a file or "-" for stdout.
        /// </summary>
        [RegularExpression(@"([\d\w_]+)|(-)", ErrorMessage = "Set filename or -.")]
        public string? Metadata { get; set; }

        /// <summary>
        /// Format to save the metadata in, either txt or json (requires --metadata).
        /// </summary>
        [Range(0, 1, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad enum value set 0 or 1.")]
        public MetadataFormatEnum? MetadataFormat { get; set; }

        /// <summary>
        ///  Manual flicker correction period. Set to 10000us to cancel 50Hz flicker. Set to 8333us to cancel 60Hz flicker.
        /// </summary>
        public FlickerPeriodModel? FlickerPeriod { get; set; }

        /// <summary>
        /// Set the video bitrate for encoding. If no units are provided, default to bits/second.
        /// </summary>
        public BitrateModel? Bitrate { get; set; }

        /// <summary>
        /// Set the encoding profile.
        /// </summary>
        public string? Profile { get; set; }

        /// <summary>
        /// Set the encoding level.
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad Level value. Use unsigned int value.")]
        public uint? Level { get; set; }

        /// <summary>
        /// Set the intra frame period.
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad Intra value. Use unsigned int value.")]
        public uint? Intra { get; set; }

        /// <summary>
        /// Force PPS/SPS header with every I frame (h264 only).
        /// </summary>
        public bool? Inline { get; set; }

        /// <summary>
        /// Set the codec to use, either h264, libav, mjpeg or yuv420.
        /// </summary>
        [Range(0, 3, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad enum value set 0-3.")]
        public CodecEnum? Codec { get; set; }

        /// <summary>
        /// Set the MJPEG quality parameter (mjpeg only). (=50)
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad Quality value. Use unsigned int value.")]
        public uint? Quality { get; set; }

        /// <summary>
        /// Save a timestamp file with this name.
        /// </summary>
        public string? SavePts { get; set; }

        /// <summary>
        /// Listen for an incoming client network connection before sending data to the client.
        /// </summary>
        public bool? Listen { get; set; }

        /// <summary>
        /// Pause or resume video recording when ENTER pressed.
        /// </summary>
        public bool? KeyPress { get; set; }

        /// <summary>
        /// Pause or resume video recording when signal received.
        /// </summary>
        public bool? Signal { get; set; }

        /// <summary>
        /// Use 'pause' to pause the recording at startup, otherwise 'record' (the default).
        /// </summary>
        [Range(0, 1, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad enum value set 0 or 1.")]
        public InitialEnum? Initial { get; set; }

        /// <summary>
        /// Create a new output file every time recording is paused and then resumed.
        /// </summary>
        public bool? Split { get; set; }

        /// <summary>
        /// Break the recording into files of approximately this many milliseconds.
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad Segment value. Use unsigned int value.")]
        public uint? Segment { get; set; }

        /// <summary>
        /// Write output to a circular buffer of the given size (in MB) which is saved on exit.
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad Circular value. Use unsigned int value.")]
        public uint? Circular { get; set; }

        /// <summary>
        /// Run for the exact number of frames specified. This will override any timeout set.
        /// </summary>
        [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad Frames value. Use unsigned int value.")]
        public uint? Frames { get; set; }

        /// <summary>
        /// Sets the libav video codec to use. To list available codecs, run  the "ffmpeg -codecs" command.
        /// </summary>
        public string? LibavVideoCodec { get; set; }

        /// <summary>
        /// Без какой-либо валидации! Валидацию следует реализовать при возникновении необходимости использовать этот параметр.
        /// Sets the libav video codec options to use. These override the internal defaults (check 'encoderOptions*()' in 'encoder/libav_encoder.cpp' for the defaults). 
        /// Separate key and value with "=" and multiple options with ";". e.g.: "preset=ultrafast;profile=high;partitions=i8x8,i4x4". To list available options
        /// for a given codec, run the "ffmpeg -h encoder=libx264" command for libx264.
        /// </summary>
        public string? LibavVideoCodecOpts { get; set; }

        /// <summary>
        /// Аналогично параметру <see cref="LibavVideoCodec"/> без валидации.
        /// Sets the libav encoder output format to use. Leave blank to try and deduce this from the filename.
        /// </summary>
        public string? LibavFormat { get; set; }

        public class PreviewModel
        {
            [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad x value in PreviewModel. Use unsigned int value.")]
            public uint X { get; set; } = 0;
            [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad x value in PreviewModel. Use unsigned int value.")]
            public uint Y { get; set; } = 0;
            [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad width value in PreviewModel. Use unsigned int value.")]
            public uint Width { get; set; } = 0;
            [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad height value in PreviewModel. Use unsigned int value.")]
            public uint Height { get; set; } = 0;

            public override string ToString()
            {
                return String.Format("{0},{1},{2},{3}", X, Y, Width, Height);
            }
        }
        public class ROIModel
        {
            [Range(0, double.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad x value in ROIModel. Use unsigned double value.")]
            public double X { get; set; } = 0;
            [Range(0, double.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad x value in ROIModel. Use unsigned double value.")]
            public double Y { get; set; } = 0;
            [Range(0, double.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad x value in ROIModel. Use unsigned double value.")]
            public double RelateWidth { get; set; } = 0;
            [Range(0, double.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad x value in ROIModel. Use unsigned double value.")]
            public double RelateHeight { get; set; } = 0;

            public override string ToString()
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.CurrencyDecimalSeparator = ".";

                return $"{X.ToString(nfi)},{Y.ToString(nfi)},{RelateWidth.ToString(nfi)},{RelateHeight.ToString(nfi)}";
            }
        }
        public class AWBGainsModel
        {
            [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad \"red\" value in AWBGainsModel. Use unsigned int value.")]
            public uint Red { get; set; } = 0;
            [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad \"blue\" value in AWBGainsModel. Use unsigned int value.")]
            public uint Blue { get; set; } = 0;

            public override string ToString()
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.CurrencyDecimalSeparator = ".";

                return String.Format("{0},{1}", Red.ToString(nfi), Blue.ToString(nfi));
            }
        }
        public class ModeModel
        {
            [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad \"w\" value in ModeModel. Use unsigned int value.")]
            public uint W { get; set; }
            [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad \"h\" value in ModeModel. Use unsigned int value.")]
            public uint H { get; set; }
            [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad \"bitdepth\" value in ModeModel. Use unsigned int value.")]
            public uint BitDepth { get; set; }
            public bool IsPacked { get; set; }

            public override string ToString()
            {
                return String.Format("{0}:{1}:{2}:{3}", W.ToString(), H.ToString(), BitDepth.ToString(), IsPacked ? "P" : "U");
            }
        }
        public struct FlickerPeriodModel
        {
            [RegularExpression(@"[um]?s", ErrorMessage = "Use us, ms or s units.")]
            public string Units { get; set; }
            [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad value in FlickerPeriodModel. Use unsigned int value.")]
            public uint Value { get; set; }

            public override string ToString()
            {
                return String.Format("{0}{1}", Value.ToString(), Units);
            }
        }
        public struct BitrateModel
        {
            [RegularExpression(@"[GMK]?[Bb]p[smh]", ErrorMessage = @"Use string with pattern: [GMK]?[Bb]p[smh]")]
            public string Units { get; set; }
            [Range(0, uint.MaxValue, MinimumIsExclusive = false, MaximumIsExclusive = false, ErrorMessage = "Bad value in BitrateModel. Use unsigned int value.")]
            public uint Value { get; set; }

            public override string ToString()
            {
                return String.Format("{0}{1}", Value.ToString(), Units);
            }
        }
        public enum MeteringEnum
        {
            Centre,
            Spot,
            Average,
            Custom
        }
        public enum ExposureEnum
        {
            Normal,
            Sport
        }
        public enum AWBEnum
        {
            Auto,
            Incandescent,
            Tungsten,
            Fluorescent,
            Indoor,
            Daylight,
            Cloudy,
            Custom
        }
        public enum DenoiseEnum
        {
            auto,
            off,
            cdn_off,
            cdn_fast,
            cdn_hq
        }
        public enum AutoFocusModeEnum
        {
            Manual,
            Auto,
            Continuous
        }
        public enum AutoFocusRangeEnum
        {
            Normal,
            Macro,
            Full
        }
        public enum AutoFocusSpeedEnum
        {
            Normal,
            Fast
        }
        public enum HDREnum
        {
            Off,
            Auto,
            Sensor,
            SingleExp
        }
        public enum MetadataFormatEnum
        {
            Txt,
            Json
        }
        public enum CodecEnum
        {
            H264,
            Libav,
            Mjpeg,
            Yuv420
        }
        public enum InitialEnum
        {
            Pause,
            Record
        }
    }
}
