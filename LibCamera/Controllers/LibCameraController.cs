﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LibCamera.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibCameraController : ControllerBase
    {
        /// <summary>
        /// Camera settings
        /// </summary>
        /// <param name="model">
        /// camera(uint): It is a camera-id. max =  4 294 967 295 min = 0
        /// 
        /// verbose(ushort): Set verbosity level. Level 0 is no output, 1 is default, 2 is verbose. max = 2 min = 0
        /// 
        /// config(string): Read the options from a file. If no filename is specified, default to config.txt. In case of duplicate options, the ones provided on the command line will be used. Note that the config file must only contain the long form options. If set "-" to Config local _config will "config.txt".
        /// 
        /// infoText(string): Sets the information string on the titlebar. Available values: %frame (frame number), %fps (framerate), %exp (shutter speed), %ag (analogue gain), %dg (digital gain), %rg (red colour gain), %bg (blue colour gain), %focus (focus FoM value), %aelock (AE locked status), %lp (lens position, if known), %afstate (AF state, if supported). Default: "#%frame (%fps fps) exp %exp ag %ag dg %dg".
        /// 
        /// width(uint): Set the output image width (0 = use default value). max =  4 294 967 295 min = 0
        /// 
        /// height(uint): Set the output image height (0 = use default value). max =  4 294 967 295 min = 0
        /// 
        /// timeOut(uint): Time for which program runs. If no units are provided, default to ms. max =  4 294 967 295 min = 0
        /// 
        /// output(string): Set the output file name.
        /// 
        /// postProcessFile(string): Set the file name for configuring the post-processing.
        /// 
        /// postProcessLibs(string): Set a custom location for the post-processing library .so files.
        /// 
        /// noPreview(boolean): Do not show a preview window.
        /// 
        /// preview(PreviewModel): Set the preview window dimensions, given as x,y,width,height e.g. 0,0,640,480.{x(uint), y(uint), width	(uint), height (uint)}
        /// 
        /// fullscreen(boolean): Use a fullscreen preview window.
        /// 
        /// qtPreview(boolean): Use Qt-based preview window (WARNING: causes heavy CPU load, fullscreen not supported).
        /// 
        /// hFlip(boolean): Request a horizontal flip transform.
        /// 
        /// vFlip(boolean): Request a vertical flip transform.
        /// 
        /// rotation(boolean): Request an image rotation, 0 or 180. 0 (false) - не зеркалит, 180 (true) - зеркалит.
        /// 
        /// roi(ROIModel): Region of Interest model. {x(double), y(double),relateWidth	(double), relateHeight (double)}
        /// 
        /// shutter(uint): Set a fixed shutter speed. If no units are provided default to us. max =  4 294 967 295 min = 0
        /// 
        /// gain(uint): Set a fixed gain value. max =  4 294 967 295 min = 0
        /// 
        /// metering(MeteringEnum): Enum value for metering mode{0 - centre, 1 - spot, 2 - average, 3 - custom}.
        /// 
        /// exposure(ExposureEnum): Enum value for exposure mode{0 - normal, 1 - sport}.
        /// 
        /// ev(uint): Set the EV exposure compensation, where 0 = no change. max =  4 294 967 295 min = 0
        /// 
        /// awb(AWBEnum): Enum value for automatic white balance mode{0 - auto, 1 - incandescent, 2 - tungsten, 3 - fluorescent, 4 - indoor, 5  - daylight, 6 - cloudy, 7 - custom}.
        /// 
        /// awbGains(AWBGainsModel): Automatic white balance gains model {red(uint): max = 4 294 967 295 min = 0, blue(uint): max = 4 294 967 295 min = 0}.
        /// 
        /// flush(boolean): Flush output data as soon as possible.
        /// 
        /// wrap(uint): When writing multiple output files, reset the counter when it reaches this number. max =  4 294 967 295 min = 0
        /// 
        /// brightness(double): Adjust the brightness of the output images, in the range -1.0 to 1.0. max = 1 min = -1
        /// 
        /// contrast(double): Adjust the contrast of the output image, where 1.0 = normal contrast. max = 1 min = 0
        /// 
        /// saturation(double): Adjust the colour saturation of the output, where 1.0 = normal and 0.0 = greyscale. max = 1 min = 0
        /// 
        /// sharpness(double): Adjust the sharpness of the output image, where 1.0 = normal sharpening. max = 1 min = 0
        /// 
        /// framerate(int): Set the fixed framerate for preview and video modes. max =  2 147 483 647 min = −2 147 483 648
        /// 
        /// denoise(DenoiseEnum): Enum value for denoise mode {0 - auto, 1 - off, 2 - cdn_off, 3 - cdn_fast, 4 - cdn_hq}.
        /// 
        /// viewFinderWidth(uint): Width of viewfinder frames from the camera (distinct from the preview window size). max =  4 294 967 295 min = 0
        /// 
        /// viewFinderHeight(uint): Height of viewfinder frames from the camera (distinct from the preview window size). max =  4 294 967 295 min = 0
        /// 
        /// tuningFile(string): Name of camera tuning file to use, omit this option for libcamera default behaviour.
        /// 
        /// loresWidth(uint): Width of low resolution frames (use 0 to omit low resolution stream). max =  4 294 967 295 min = 0
        /// 
        /// loresHeight(uint): Height of low resolution frames (use 0 to omit low resolution stream). max =  4 294 967 295 min = 0
        /// 
        /// mode(ModeModel): Mode model for camera operation {w(uint), h(uint),bitDepth(uint), isPacked (bool)}. max uint =  4 294 967 295 min  uint = 0
        /// 
        /// viewFinderMode(ModeModel): Mode model for viewfinder operation {w(uint), h(uint),bitDepth(uint), isPacked (bool)}. max uint =  4 294 967 295 min  uint = 0
        /// 
        /// bufferCount(uint): Number of in-flight requests (and buffers) configured for video, raw, and still. max =  4 294 967 295 min = 0
        /// 
        /// viewFinderBufferCount(uint): Number of in-flight requests (and buffers) configured for preview window. max =  4 294 967 295 min = 0
        /// 
        /// noRaw(boolean): Disable requesting of a RAW stream. Will override any manual mode request when setting framerate.
        /// 
        /// autoFocusMode(AutoFocusModeEnum): Enum value for auto focus mode{0 - manual, 1 - auto, 2 - continuous}.
        /// 
        /// autoFocusRange(AutoFocusRangeEnum): Enum value for auto focus range{0 - normal, 1 - macro, 2 - full}.
        /// 
        /// autoFocusSpeed(AutoFocusSpeedEnum): Enum value for auto focus speed{0 - normal, 1 - fast}.
        /// 
        /// autoFocusWindow(ROIModel): Region of Interest model for auto focus window.{x(double), y(double), relateWidth (double), relateHeight (double)}
        /// 
        /// lensPosition(string): Set the lens to a particular focus position, expressed as a reciprocal distance (0 moves the lens to infinity), or "default" for the hyperfocal distance. Pattern: (0)|(default).
        /// 
        /// hdr(HDREnum): Enum value for high dynamic range mode {0 - off, 1 - auto, 2 - sensor,3 - single-exp}.
        /// 
        /// metadata(string): Save captured image metadata to a file or "-" for stdout. Pattern: ([\d\w_]+)|(-). Example: e3_2_14  or -
        /// 
        /// metadataFormat(MetadataFormatEnum): Enum value for metadata format.{0 - txt, 1 - json}
        /// 
        /// flickerPeriod(FlickerPeriodModel): Flicker period model for adjustments. {units (string) {us, ms or s},  value (int)}
        /// 
        /// bitrate(BitrateModel): Bitrate model for video encoding. {units (string) {Use string with pattern: [GMK]?[Bb]p[smh]},  value (int)}
        /// 
        /// profile(string): Set the encoding profile. 
        /// 
        /// level(uint): Set the encoding level. max =  4 294 967 295 min = 0
        ///  
        /// intra(uint): Set the intra frame period. max =  4 294 967 295 min = 0
        /// 
        /// inline(boolean): Force PPS/SPS header with every I frame (h264 only).
        /// 
        /// codec(CodecEnum): Enum value for codec type.{0 - H264, 1 - Libav, 2 -Mjpeg, 3 - Yuv420}
        /// 
        /// savePts (string): Save a timestamp file with this name.
        /// 
        /// quality(uint): Set the MJPEG quality parameter (mjpeg only). Default = 50. max =  4 294 967 295 min = 0
        /// 
        /// listen(boolean): Listen for an incoming client network connection before sending data to the client.
        /// 
        /// keyPress(boolean): Pause or resume video recording when ENTER pressed.
        /// 
        /// signal(boolean): Pause or resume video recording when signal received.
        /// 
        /// initial(InitialEnum): Enum value for initial state.{0 - pause, 1 - record}
        /// 
        /// split(boolean): Create a new output file every time recording is paused and then resumed.
        /// 
        /// segment(uint): Break the recording into files of approximately this many milliseconds. max =  4 294 967 295 min = 0
        /// 
        /// circular(uint): Write output to a circular buffer of the given size (in MB) which is saved on exit. max =  4 294 967 295 min = 0
        /// 
        /// frames(uint): Run for the exact number of frames specified. This will override any timeout set. max =  4 294 967 295 min = 0
        /// 
        /// libavVideoCodec(string): Sets the libav video codec to use. To list available codecs, run the "ffmpeg -codecs" command.
        /// 
        /// libavVideoCodecOpts(string): Sets the libav video codec options to use. These override the internal defaults (check 'encoderOptions*()' in 'encoder/libav_encoder.cpp' for the defaults). Separate key and value with "=" and multiple options with ";". e.g.: "preset=ultrafast;profile=high;partitions=i8x8,i4x4". To list available options for a given codec, run the "ffmpeg -h encoder=libx264" command for libx264.
        /// 
        /// libavFormat(string): Sets the libav encoder output format to use. Leave blank to try and deduce this from the filename.
        /// 
        /// </param>
        /// <returns>String with parameters</returns>
        [HttpPost]
        public string Test(LibCameraModel model)
        {

            return (model.ToString());
        }
    }
}
