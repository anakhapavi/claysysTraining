//validate first name
function validateFirstName() {
    const firstNameInput = document.getElementById('firstName');
    const firstNameError = document.getElementById('firstNameError');
    const firstName = firstNameInput.value.trim();
  
    if (firstName === '') {
      firstNameError.textContent = 'First Name cannot be blank';
    } else {
      firstNameError.textContent = '';
    }
  }

  //validate last name
  function validateLastName() {
    const lastNameInput = document.getElementById('lastName');
    const lastNameError = document.getElementById('lastNameError');
    const lastName = lastNameInput.value.trim();
  
    if (lastName === '') {
      lastNameError.textContent = 'Last Name cannot be blank';
    } else {
      lastNameError.textContent = '';
    }
  }

  // email validation 
function validateEmail() 
{
  const emailInput = document.getElementById('email');
  const emailError = document.getElementById('emailError');

  // Regular expression for email validation
  const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

  if (!emailRegex.test(emailInput.value)) 
 {
    // Showing the error message if the email is invalid
    emailError.style.display = 'block';
    emailInput.classList.add('invalid');
  } 
else
 {
    // Hide the error message if the email is valid
    emailError.style.display = 'none';
    emailInput.classList.remove('invalid');
  }
}

  // phone validation 
  

  function validateMobileNumber() {
    const mobileNumberInput = document.getElementById('mobileNumber');
    const mobileNumberError = document.getElementById('mobileNumberError');
    const mobileNumberRegex = /^\d{10}$/;
  
    if (!mobileNumberRegex.test(mobileNumberInput.value)) {
      mobileNumberError.textContent = 'Please enter a valid 10-digit phone number.';
      mobileNumberError.style.display = 'block';
      mobileNumberInput.classList.add('invalid');
    } else {
      mobileNumberError.style.display = 'none';
      mobileNumberInput.classList.remove('invalid');
    }
  }

  //validate username
  function validateUsername() {
    const usernameInput = document.getElementById('username1');
    const usernameError = document.getElementById('usernameError');
    const username = usernameInput.value.trim();
    const disallowedCharsPattern = /[^\w-.]/;
    if (username === '') 
    {
      usernameError.textContent = 'Username cannot be blank';
    } 
    else if (username.length < 5)
   {
      usernameError.textContent = 'Username must be at least 5 characters long.';
    }
    else if(disallowedCharsPattern.test(username))
   {
     usernameError.textContent = 'Username contains disallowed characters, only alphabets,numbers and underscore allowed!';
   }
    else
   {
      usernameError.textContent = '';
    }
  }

  //validate password
  function validatePassword() {
    const passwordInput = document.getElementById('password1');
    const passwordError = document.getElementById('passwordError');
    const password = passwordInput.value.trim();
  
    if (password === '') {
      passwordError.textContent = 'Password cannot be blank';
    } else if (password.length < 8) {
      passwordError.textContent = 'Password must be at least 8 characters long.';
    } else {
      passwordError.textContent = '';
    }
  }

  //validate confirm password
   function validateCpassword() {
    const passwordInput = document.getElementById('password1');
    const cpasswordInput = document.getElementById('cpassword');
    const cpasswordError = document.getElementById('cpasswordError');
  
    const password = passwordInput.value;
    const confirmPassword = cpasswordInput.value;
  
   if (password !== confirmPassword) {
      cpasswordError.textContent = 'Passwords do not match.';
    } else {
      cpasswordError.textContent = '';
    }
  }

  //submission
  function validateForm(event) {
    event.preventDefault(); // Prevent form submission for now
  
    // Check password match
    validatePasswordMatch();
  
    // If there are no errors, submit the form
    if (confirmPasswordError.textContent === '') {
      event.target.submit();
    }
  }

  function validateUsername1() {
    const usernameInput = document.getElementById('username');
    const username = usernameInput.value.trim();
    const usernameErrorSpan = document.getElementById('usernameError');

    const validUsernameRegex = /^[a-zA-Z0-9_]{4,20}$/;

    if (validUsernameRegex.test(username)) {
        usernameErrorSpan.textContent = '';
    } else {
        usernameErrorSpan.textContent = 'Username must be 4 to 20 characters long and can only contain letters, numbers, and underscores.';
    }
}

function validatePassword1() {
    const passwordInput = document.getElementById('password');
    const password = passwordInput.value;

    const passwordErrorSpan = document.getElementById('passwordError');
    const uppercaseRegex = /[A-Z]/;
    const lowercaseRegex = /[a-z]/;
    const digitRegex = /\d/;

    if (password.length >= 8 &&
        uppercaseRegex.test(password) &&
        lowercaseRegex.test(password) &&
        digitRegex.test(password)) {
        passwordErrorSpan.textContent = '';
    } else {
        passwordErrorSpan.textContent = 'Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit.';
    }
}