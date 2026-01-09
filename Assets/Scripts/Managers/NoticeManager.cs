using System.Collections;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class NoticeManager : SingletonMonoBehavior<NoticeManager>
    {
        [SerializeField] private TextMeshProUGUI noticeText;
        [SerializeField] private int noticeTime;
        private Coroutine _coroutine;
        
        public static void Notice(string message)
        {
            Instance.noticeText.text = message;
            Instance.noticeText.color = Color.white;
            if (Instance._coroutine != null) Instance.StopCoroutine(Instance._coroutine);
            Instance._coroutine = Instance.StartCoroutine(Instance.HideNotice());
        }

        private IEnumerator HideNotice()
        {
            yield return new WaitForSeconds(noticeTime);
            var time = 1f;
            while (time >= 0f)
            {
                noticeText.color = new Color(1, 1, 1, time);
                time -= Time.deltaTime;
                yield return null;
            }
            noticeText.color = new Color(1, 1, 1, 0);
            _coroutine = null;
        }
    }
}
