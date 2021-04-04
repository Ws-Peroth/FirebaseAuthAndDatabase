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
        AuthManager.authManager.DoSignUp(signUpEmail.text, signUpPassword.text, signUpUserName.text);
    }

    public void LoginSignUpButtonDown() // Login 페이지의 SignUp 실행 코드
    {
        startPage.SetActive(false);
        loginPage.SetActive(false);
        signUpPage.SetActive(true);
    }

    public void LoginEnterButtonDown() // Login 페이지의 Enter 실행 코드
    {
        AuthManager.authManager.DoLogin(signUpEmail.text, signUpPassword.text);
    }

    public void SignUpPageToLoginPage()
    {
        startPage.SetActive(false);
        loginPage.SetActive(true);
        signUpPage.SetActive(false);
    }

}
