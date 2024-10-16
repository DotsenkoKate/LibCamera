using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCamera
{
    public partial class LibCameraModel
    {
        public LibCameraModel()
        {
            _verbose = null;
            _config = null;
            _brightness = null;
            _contrast = null;
            _saturation = null;
            _sharpness = null;
        }

        public LibCameraModel(InvalidValueActionDelegate ivaDel)
        {
            _verbose = null;
            _config = null;
            _brightness = null;
            _contrast = null;
            _saturation = null;
            _sharpness = null;

            InvalidValueActionEvent += ivaDel;
        }

        /// <summary>
        /// Что-то интересное.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.CurrencyDecimalSeparator = ".";

            result.Append("libcamera-vid");
            if (Camera != null) result.Append($" --camera {Camera.ToString()}");
            if (Verbose != null) result.Append($" --verbose {Verbose.ToString()}");
            if (Config != null) result.Append($" --config {Config}");
            if (InfoText != null) result.Append($" --info-text {InfoText}");
            if (Width != null) result.Append($" --width {Width.ToString()}");
            if (Height != null) result.Append($" --height {Height.ToString()}");
            if (TimeOut != null) result.Append($" -t {TimeOut.ToString()}");
            if (Output != null) result.Append($" --output {Output}");
            if (PostProcessFile != null) result.Append($" --post-process-file {PostProcessFile}");
            if (PostProcessLibs != null) result.Append($" --post-process-libs {PostProcessLibs}");
            if (NoPreview != null && NoPreview.Value) result.Append($" -n");
            if (Preview != null) result.Append($" -p {Preview.ToString()}");
            if (QTPreview != null && QTPreview.Value) result.Append($" --qt-preview");
            if (Fullscreen != null && Fullscreen.Value && (QTPreview == null || !(bool)QTPreview)) result.Append($" -f");
            if (HFlip != null && HFlip.Value) result.Append($" --hflip");
            if (VFlip != null && VFlip.Value) result.Append($" --vflip");
            if (Rotation != null && Rotation.Value) result.Append($" --rotation 180");
            if (ROI != null) result.Append($" --roi {ROI.ToString()}");
            if (Shutter != null) result.Append($" --shutter {Shutter.ToString()}");
            if (Gain != null) result.Append($" --gain {Gain.ToString()}");
            if (Metering != null) result.Append($" --metering {Enum.GetName((MeteringEnum)Metering)!.ToLower()}");
            if (Exposure != null) result.Append($" --exposure {Enum.GetName((ExposureEnum)Exposure)!.ToLower()}");
            if (EV != null) result.Append($" --ev {EV.ToString()}");
            if (AWB != null) result.Append($" --awb {Enum.GetName((AWBEnum)AWB)!.ToLower()}");
            if (AWBGains != null) result.Append($" --awbgains {AWBGains.ToString()}");
            if (Flush != null && Flush.Value) result.Append($" --flush");
            if (Wrap != null) result.Append($" --wrap {Wrap.ToString()}");
            if (Brightness != null) result.Append($" --brightness {Brightness.Value.ToString(nfi)}");
            if (Contrast != null) result.Append($" --contrast {Contrast.Value.ToString(nfi)}");
            if (Saturation != null) result.Append($" --saturation {Saturation.Value.ToString(nfi)}");
            if (Sharpness != null) result.Append($" --sharpness {Sharpness.Value.ToString(nfi)}");
            if (Framerate != null) result.Append($" --framerate {Framerate.ToString()}");
            if (Denoise != null) result.Append($" --denoise {Enum.GetName((DenoiseEnum)Denoise)!.ToLower()}");
            if (ViewFinderWidth != null) result.Append($" --viewfinder-width {ViewFinderWidth.ToString()}");
            if (ViewFinderHeight != null) result.Append($" --viewfinder-height {ViewFinderHeight.ToString()}");
            if (TuningFile != null) result.Append($" --tuning-file {TuningFile}");
            if (LoresWidth != null) result.Append($" --lores-width {LoresWidth.ToString()}");
            if (LoresHeight != null) result.Append($" --lores-height {LoresHeight.ToString()}");
            if (Mode != null) result.Append($" --mode {Mode.ToString()}");
            if (ViewFinderMode != null) result.Append($" --viewfinder-mode {ViewFinderMode.ToString()}");
            if (BufferCount != null) result.Append($" --buffer-count {BufferCount.ToString()}");
            if (ViewFinderBufferCount != null) result.Append($" --viewfinder-buffer-count {ViewFinderBufferCount.ToString()}");
            if (NoRaw != null && NoRaw.Value) result.Append($" --no-raw");
            if (AutoFocusMode != null) result.Append($" --autofocus-mode {Enum.GetName((AutoFocusModeEnum)AutoFocusMode)!.ToLower()}");
            if (AutoFocusRange != null) result.Append($" --autofocus-range {Enum.GetName((AutoFocusRangeEnum)AutoFocusRange)!.ToLower()}");
            if (AutoFocusSpeed != null) result.Append($" --autofocus-speed {Enum.GetName((AutoFocusSpeedEnum)AutoFocusSpeed)!.ToLower()}");
            if (AutoFocusWindow != null) result.Append($" --autofocus-window {AutoFocusWindow.ToString()}");
            if (LensPosition != null) result.Append($" --lens-position {LensPosition}");
            if (HDR != null) result.Append($" --hdr {Enum.GetName((HDREnum)HDR)!.ToLower()}");
            if (Metadata != null) result.Append($" --metadata {Metadata}");
            if (MetadataFormat != null) result.Append($" --metadata-format {Enum.GetName((MetadataFormatEnum)MetadataFormat)!.ToLower()}");
            if (FlickerPeriod != null) result.Append($" --flicker-period {FlickerPeriod.ToString()}");
            if (Bitrate != null) result.Append($" -b {Bitrate.ToString()}");
            if (Profile != null) result.Append($" --profile {Profile}");
            if (Level != null) result.Append($" --level {Level.ToString()}");
            if (Intra != null) result.Append($" --intra {Intra.ToString()}");
            if (Inline != null && Inline.Value) result.Append($" --inline");
            if (Codec != null) result.Append($" --codec {Enum.GetName((CodecEnum)Codec)!.ToLower()}");
            if (SavePts != null) result.Append($" --save-pts {SavePts}");
            if (Quality != null) result.Append($" -q {Quality.ToString()}");
            if (Listen != null && Listen.Value) result.Append($" -l");
            if (KeyPress != null && KeyPress.Value) result.Append($" -k");
            if (Signal != null && Signal.Value) result.Append($" -s");
            if (Initial != null) result.Append($" -i {Enum.GetName((InitialEnum)Initial)!.ToLower()}");
            if (Split != null && Split.Value) result.Append($" --split");
            if (Segment != null) result.Append($" --segment {Segment.ToString()}");
            if (Circular != null) result.Append($" --circular {Circular.ToString()}");
            if (Frames != null) result.Append($" --frames {Frames.ToString()}");
            if (LibavVideoCodec != null) result.Append($" --libav-video-codec {LibavVideoCodec}");
            if (LibavVideoCodecOpts != null) result.Append($" --libav-video-codec-opts {LibavVideoCodecOpts}");
            if (LibavFormat != null) result.Append($" --libav-format {LibavFormat}");

            return result.ToString();
        }

        public event InvalidValueActionDelegate InvalidValueActionEvent;
        public delegate void InvalidValueActionDelegate(string propertyName);
    }
}
