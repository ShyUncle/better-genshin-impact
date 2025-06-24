using BetterGenshinImpact.Core.Recognition;
using BetterGenshinImpact.Core.Recognition.OCR;
using BetterGenshinImpact.Core.Recognition.ONNX;
using BetterGenshinImpact.Core.Recognition.ONNX.SVTR;
using BetterGenshinImpact.Core.Recognition.OpenCv;
using BetterGenshinImpact.Core.Simulator;
using BetterGenshinImpact.GameTask;
using BetterGenshinImpact.GameTask.Model;
using Microsoft.Extensions.Logging.Abstractions;
using OpenCvSharp;
using System.Collections.Concurrent;
using System.Diagnostics;
using static Vanara.PInvoke.User32;

namespace BetterGenshinImpact.Test.Simple;

public class OcrTest
{
    public static void TestYap()
    {
        var path = @"D:\daydayup\better-genshin-impact\BetterGenshinImpact\Assets\Model\PaddleOCR\0.png";
        //Mat mat = Cv2.ImRead(path);
        //var text = TextInferenceFactory.Pick.Inference(TextInferenceFactory.PreProcessForInference(mat));
        //Debug.WriteLine(text);
        Mat mat2 = Cv2.ImRead(path); 
        var paddle = OcrFactory.Paddle;
        var text2 = paddle.Ocr(mat2);
        Debug.WriteLine(text2);

        var fpath = @"D:\daydayup\better-genshin-impact\Test\BetterGenshinImpact.Test\Simple\f.jpg";
        var dpath = @"D:\daydayup\better-genshin-impact\Test\BetterGenshinImpact.Test\Simple\d.jpg";
        var roi = Cv2.ImRead(dpath);
        var template = Cv2.ImRead(fpath);
        var p = MatchTemplateHelper.MatchTemplate(roi, template, TemplateMatchModes.CCoeffNormed, null, 0.8);
        if (p != default)
        { 
            Cv2.Rectangle(roi, p, new OpenCvSharp.Point(p.X + template.Width, p.Y + template.Height), Scalar.Red, 2);
            Cv2.ImWrite("D:\\daydayup\\better-genshin-impact\\Test\\BetterGenshinImpact.Test\\Simple\\find.jpg", roi);
            Cv2.ImShow("Match Result", roi);
            Cv2.WaitKey();
        }
        else
        {
            Debug.WriteLine("No match found.");
        }
    }
}
