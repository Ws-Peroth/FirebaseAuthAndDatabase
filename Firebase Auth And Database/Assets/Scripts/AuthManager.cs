using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;


public class AuthManager : MonoBehaviour
{
    public static AuthManager authManager;
    public AuthUI ui;

    public GameObject signUpErrorToast;
    public GameObject loginErrorToast;

    void Start()
    {
        DontDestroyOnLoad(this);
        if (authManager == null)
        {
            authManager = this;
        }
    }

    public void DoLogin(string email, string password)
    {

    }

    public void DoSignUp(string email, string password, string name)
    {
        ui.SignUpPageToLoginPage();
    }

}
