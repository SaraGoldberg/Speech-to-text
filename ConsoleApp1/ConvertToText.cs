using System;
using System.Collections.Generic;
using System.Text;
using Google.Cloud.Speech.V1;

namespace SpeechToText
{
    public class ConvertToText
    {
        public static string SpeechToText()
        {
            var speech = SpeechClient.Create();
            var config = new RecognitionConfig
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Flac,
                SampleRateHertz = 16000,
                LanguageCode = LanguageCodes.Hebrew.Israel,
                EnableWordTimeOffsets = true
            };
            var audio = RecognitionAudio.FromStorageUri("gs://cloud-samples-tests/speech/brooklyn.flac");

            var response = speech.Recognize(config, audio);
            string res = "";
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    res += alternative.Transcript + "\nWord details:\n";
                    foreach (var item in alternative.Words)
                    {
                       res += item.Word + "\nWordStartTime: " + item.StartTime + "\nWordEndTime:" + item.EndTime + "\n";
                    } 
                }
            }
            Console.WriteLine(res);
            return res;
        }
    }
}
