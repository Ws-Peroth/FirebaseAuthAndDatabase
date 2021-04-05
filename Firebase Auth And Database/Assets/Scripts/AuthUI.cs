using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuthUI : MonoBehaviour
{
    public GameObject backGround;
    public GameObject startPage;
    public GameObject loginPage;
    public GameObject signUpPage;
    public GameObject signUpErrorToast;
    public GameObject loginErrorToast;

    public Text signUpErrorToastMessage;
    public Text loginErrorToastMessage;

    public InputField loginEmail;
    public InputField loginPassword;

    public InputField signUpEmail;
    public InputField signUpPassword;
    public InputField signUpUserName;

    public int currentPageNumber;
    // 0 : Start Page, 1 : Login Page, 2 : SignUp Page


    void Start()
    {
        currentPageNumber = 0;

        signUpErrorToast.SetActive(false);
        loginErrorToast.SetActive(false);
        backGround.SetActive(true);
        startPage.SetActive(true);
        loginPage.SetActive(false);
        signUpPage.SetActive(false);

    }

    public void StartLoginButtonDown() // Start 페이지의 LoginButton 실행 코드
    {
        startPage.SetActive(false);
        loginPage.SetActive(true);
        signUpPage.SetActive(false);
    }

    public void StartSignUpButtonDown() // Start 페이지의 SignUpButton 실행 코드
    {
        startPage.SetActive(false);
        loginPage.SetActive(false);
        signUpPage.SetActive(true);
    }

    public void SignUpLoginButtonDown() // SignUp 페이지의 LoginButton 실행 코드
    {
        startPage.SetActive(false);
        loginPage.SetActive(true);
        signUpPage.SetActive(false);
    }

    public void SignUpEnterButtonDown() // SignUp 페이지의 Enter 실행 코드
    {
        string email = signUpEmail.text;
        string password = signUpPassword.text;
        string name = signUpUserName.text;

        AuthManager.authManager.DoSignUp(email, password, name);
        signUpEmail.text = "";
        signUpPassword.text = "";
        signUpUserName.text = "";
    }

    public void LoginSignUpButtonDown() // Login 페이지의 SignUp 실행 코드
    {
        startPage.SetActive(false);
        loginPage.SetActive(false);
        signUpPage.SetActive(true);
    }

    public void LoginEnterButtonDown() // Login 페이지의 Enter 실행 코드
    {
        string email = loginEmail.text;
        string password = loginPassword.text;
        AuthManager.authManager.DoLogin(email, password);
        loginEmail.text = "";
        loginPassword.text = "";

    }

    public void SignUpPageToLoginPage()
    {
        print("call function : " + nameof(SignUpPageToLoginPage));
        startPage.SetActive(false);
        loginPage.SetActive(true);
        signUpPage.SetActive(false);
    }

    public void ShowSignUpErrorToast(string errorMessage)
    {
        signUpErrorToast.SetActive(true);
        signUpErrorToastMessage.text = errorMessage;
    }

    public void ExitSignErrorToast()
    {
        signUpErrorToastMessage.text = "";
        signUpErrorToast.SetActive(false);
    }

    public void ShowLoginErrorToast(string errorMessage)
    {
        loginErrorToast.SetActive(true);
        loginErrorToastMessage.text = errorMessage;
    }

    public void ExitLoginErrorToast()
    {
        loginErrorToastMessage.text = "";
        loginErrorToast.SetActive(false);
    }

}
