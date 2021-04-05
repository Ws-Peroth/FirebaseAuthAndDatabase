using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;


public class AuthManager : MonoBehaviour
{
    private FirebaseAuth auth; // 인증 객체 불러오기

    public static AuthManager authManager;
    public AuthUI authUI;



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
        print("TODO : Login\n" +
            "email = " + email +
            "\npassword = " + password);

        //StartCoroutine();

        // 이메일과 비밀번호로 가입하는 함수
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(
            task =>
            {               
                if (task.IsCompleted && !task.IsFaulted && !task.IsCanceled)
                {
                    print(email + " 로 로그인 하셨습니다.");
                    print("User ID : " + auth.CurrentUser.UserId);
                }
                else
                {
                    print("로그인에 실패하셨습니다.");
                    authUI.ShowLoginErrorMessage("로그인에 실패하셨습니다.");
                    //authUI.loginComplete = true;
                }
            }
        );
    }



    public void DoSignUp(string email, string password, string name)
    {
        print("TODO : SignUp\n" +
            "email = " + email +
            "\npassword = " + password +
            "\nname = " + name);

        // 이메일과 비밀번호로 가입하는 함수
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(
             task =>
             {
                 if (!task.IsCanceled && !task.IsFaulted)
                 {
                     print(email + " 로 회원가입 하셨습니다.");
                     authUI.GetComponent<AuthUI>().SignUpPageToLoginPage();
                 }
                 else
                 {
                     int taskStatus = 0;
                     if (task.IsFaulted) taskStatus = 1;
                     if (task.IsCanceled) taskStatus = 2;
                     SignUpExceptions(taskStatus, task.Exception.ToString());
                 }
             }
         );
    }

    private void SignUpExceptions(int taskStatus, string errorCode)
    {
        print("회원가입에 실패하셨습니다.");

        if (taskStatus == 1)
            ErrorCodeToErrorMessage(errorCode);
        else if (taskStatus == 2)
            authUI.ShowSignUpErrorMessage("Create User With Email And Password Async was canceled.");
        else
            print("ERROR");
        return;
    }

    private void ErrorCodeToErrorMessage(string errorMessage)
    {
        string result = errorMessage.Split(
               new string[] { "Firebase.FirebaseException:" },
               System.StringSplitOptions.None)[1];

        result = result.Split('\n')[0];

        authUI.ShowSignUpErrorMessage(result);

    }
}
