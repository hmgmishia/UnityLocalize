using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

namespace hmgm.UnityLocalize.Google
{
    public static class GoogleTranslate
    {
        private const string UrlFormat = "{0}?word={1}&fromL={2}&toL={3}";

        [Serializable]
        public class Result
        {
            public string result;
        }

        public class TranslateResult
        {
            public string Result { get; private set; }
            public bool IsError { get; private set; }

            public TranslateResult(string result, bool isError)
            {
                this.Result = result;
                this.IsError = isError;
            }
        }

        public static void TranslateAsync(string url, string word, SystemLanguage from, SystemLanguage to, Action<string> onCompleted, Action onError)
        {
            TranslateRawAsync(url, word, GoogleTranslateLanguage.GetLanguage(from), GoogleTranslateLanguage.GetLanguage(to), onCompleted, onError);
        }

        public static void TranslateRawAsync(string url, string word, string from, string to, Action<string> onCompleted, Action onError)
        {
            var request = UnityWebRequest.Get(string.Format(UrlFormat, url, word, from, to));
            var sended = request.SendWebRequest();
            sended.completed += operation =>
            {
                if (!request.isNetworkError)
                {
                    var result = JsonUtility.FromJson<Result>(request.downloadHandler.text);
                    onCompleted?.Invoke(result.result);
                    return;
                }

                onError?.Invoke();
            };
        }

        public static TranslateResult Translate(string url, string word, SystemLanguage from, SystemLanguage to)
        {
            return TranslateRaw(url, word, GoogleTranslateLanguage.GetLanguage(from), GoogleTranslateLanguage.GetLanguage(to));
        }

        public static TranslateResult TranslateRaw(string url, string word, string from, string to)
        {
            var request = UnityWebRequest.Get(string.Format(UrlFormat, url, word, from, to));
            var sended = request.SendWebRequest();
            while (!sended.isDone)
            {
                Thread.Sleep(1);
            }

            if (!request.isNetworkError)
            {
                Debug.Log(request.downloadHandler.text);
                var result = JsonUtility.FromJson<Result>(request.downloadHandler.text);
                return new TranslateResult(result.result, false);
            }

            return new TranslateResult("", true);
        }
    }
}