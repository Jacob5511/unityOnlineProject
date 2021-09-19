using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
 
public class html : MonoBehaviour {
    void Start() {
        StartCoroutine(Upload());
    }
     
    IEnumerator Upload() 
    {
        WWWForm form = new WWWForm();
        form.AddField("login", "jacob");
        UnityWebRequest loginPage = UnityWebRequest.Get("http://127.0.0.1:8000/registration");
        yield return loginPage.SendWebRequest ();
        if(loginPage.isNetworkError || loginPage.isHttpError) {
            Debug.Log(loginPage.error);
            yield break;
        }


        // get the csrf cookie
        string SetCookie = loginPage.GetResponseHeader ("set-cookie");
        Debug.Log (SetCookie);
        Regex rxCookie = new Regex("csrftoken=(?<csrf_token>.{64});");
        MatchCollection cookieMatches = rxCookie.Matches (SetCookie);
        string csrfCookie = cookieMatches[0].Groups ["csrf_token"].Value;
        print(csrfCookie);
        // get the middleware value
        string loginPageHtml = loginPage.downloadHandler.text;
        print(loginPageHtml);
        Regex rxMiddleware = new Regex("name=\"csrfmiddlewaretoken\" value=\"(?<csrf_token>.{64})\"");
        MatchCollection middlewareMatches = rxMiddleware.Matches(loginPageHtml);
        string csrfMiddlewareToken = middlewareMatches[0].Groups ["csrf_token"].Value;
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add( new MultipartFormDataSection("login=lol") );
        formData.Add(new MultipartFormDataSection("csrfmiddlewaretoken=" + csrfMiddlewareToken)); 
        print(csrfMiddlewareToken);
        UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/registration", formData);
        www.SetRequestHeader ("referer", "http://127.0.0.1:8000/registration");
        // www.SetRequestHeader ("cookie", "csrftoken=" + csrfCookie);
        www.SetRequestHeader ("X-CSRFToken", csrfCookie);
        yield return www.SendWebRequest();
     
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Form upload complete!");
        }
    }
}
