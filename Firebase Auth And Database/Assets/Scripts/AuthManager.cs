using System.Collections;
using UnityEngine;
using Firebase.Auth;


public class AuthManager : MonoBehaviour
{
    private FirebaseAuth auth; // 인증 객체 불러오기

    public static AuthManager authManager;
    public AuthUI authUI;

    private int errorFlag;
    private int taskStatus;
    private string signUpExceptionMessage;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance; // 인증 객체 초기화
        DontDestroyOnLoad(this);
        if (authManager == null)
        {
            authManager = this;
        }
    }

    public void DoLogin(string email, string password)
    {
        errorFlag = -2;
        signUpExceptionMessage = "";
        StartCoroutine(WaitLoginFinish());

        // 이메일과 비밀번호로 가입하는 함수
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(
            task =>
            {               
                if (task.IsCompleted && !task.IsFaulted && !task.IsCanceled)
                {
                    errorFlag = 0;
                }
                else
                {
                    errorFlag = -1;
                }
            }
        );
    }

    IEnumerator WaitLoginFinish()
    {
        while(errorFlag == -2)
        {
            yield return null;
        }
        LoginExcptions();
    }

    public void LoginExcptions()
    {
        if(errorFlag == -1)
        {
            authUI.ShowLoginErrorMessage("로그인에 실패하셨습니다.");
        }
        else if(errorFlag == 0)
        {
            print("User ID : " + auth.CurrentUser.UserId);
        }
    }

    public void DoSignUp(string email, string password, string name)
    {
        taskStatus = -3;
        signUpExceptionMessage = "";
        StartCoroutine(WaitSignUpFinish());
        print("TODO : SignUp\n" + "email = " + email + "\npassword = " + password + "\nname = " + name);

        // 이메일과 비밀번호로 가입하는 함수
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(
             task =>
             {
                 if (!task.IsCanceled && !task.IsFaulted)
                 {
                     taskStatus = 1;                     
                 }
                 else
                 {
                     if (task.IsFaulted) taskStatus = -1;
                     else if (task.IsCanceled) taskStatus = -2;
                     else taskStatus = 0;
                     signUpExceptionMessage = task.Exception.ToString();
                 }
             }
         );
    }

    IEnumerator WaitSignUpFinish()
    {
        while(taskStatus == -3)
        {
            yield return null;
        }
        if(taskStatus == 1)
        {
            authUI.ShowSignUpErrorMessage("회원가입에 성공하였습니다.", true);
        }
        else
        {
            SignUpExceptions(taskStatus, signUpExceptionMessage);
        }
    }

    private void SignUpExceptions(int taskStatus, string errorCode)
    {
        if (taskStatus == -1)
            ErrorCodeToErrorMessage(errorCode);
        else if (taskStatus == -2)
            authUI.ShowSignUpErrorMessage("Create User With Email And Password Async was canceled.", false);
        else
            authUI.ShowSignUpErrorMessage("ERROR", false);
        return;
    }

    private void ErrorCodeToErrorMessage(string errorMessage)
    {
        string result = errorMessage.Split(
               new string[] { "Firebase.FirebaseException:" },
               System.StringSplitOptions.None)[1];

        result = result.Split('\n')[0];

        authUI.ShowSignUpErrorMessage(result, false);
    }
}
