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

    public GameObject signUpErrorMessageRect;
    public GameObject loginErrorMessageRect;

    public Text signUpErrorMessage;
    public Text loginErrorMessage;

    public InputField loginEmail;
    public InputField loginPassword;

    public InputField signUpEmail;
    public InputField signUpPassword;
    public InputField signUpUserName;

    public int currentPageNumber;
    // 0 : Start Page, 1 : Login Page, 2 : SignUp Page

    private bool isSignSuccess;

    void Start()
    {
        PageInit();
    }

    public void PageInit()
    {
        currentPageNumber = 0;
        isSignSuccess = false;

        signUpErrorMessageRect.SetActive(false);
        loginErrorMessageRect.SetActive(false);
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
        startPage.SetActive(false);
        loginPage.SetActive(true);
        signUpPage.SetActive(false);
    }

    public void ShowSignUpErrorMessage(string errorMessage, bool isSignSuccess)
    {
        this.isSignSuccess = isSignSuccess;

        signUpErrorMessageRect.SetActive(true);
        signUpErrorMessage.text = errorMessage;
    }

    public void ExitSignErrorMessage()
    {
        signUpErrorMessage.text = "";
        signUpErrorMessageRect.SetActive(false);

        if (isSignSuccess)
        {
            SignUpPageToLoginPage();
            isSignSuccess = false;
        }
    }

    public void ShowLoginErrorMessage(string errorMessage)
    {
        loginErrorMessageRect.SetActive(true);
        loginErrorMessage.text = errorMessage;
    }

    public void ExitLoginErrorMessage()
    {
        loginErrorMessage.text = "";
        loginErrorMessageRect.SetActive(false);
    }

}
