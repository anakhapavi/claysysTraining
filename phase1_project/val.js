//validate first name
function validateFirstName() {
    const firstNameInput = document.getElementById('firstName');
    const firstNameError = document.getElementById('firstNameError');
    const firstName = firstNameInput.value.trim();
    const firstNameRegex = /^[a-zA-Z]+$/;

  
    if (firstName === '') {
      firstNameError.textContent = 'First Name cannot be blank'; }
    
    else if (!firstNameRegex.test(firstNameInput.value)) {
      firstNameError.textContent = 'Please enter letters only';
      firstNameError.style.display = 'block';
      firstNameInput.classList.add('invalid');
    } else {
      firstNameError.style.display = 'none';
      firstNameInput.classList.remove('invalid');
      firstName.textContent='';
    }
  }

  //validate last name
  function validateLastName() {
    const lastNameInput = document.getElementById('lastName');
    const lastNameError = document.getElementById('lastNameError');
    const lastName = lastNameInput.value.trim();
    const lastNameRegex = /^[a-zA-Z]+$/;

  
    if (lastName === '') {
      lastNameError.textContent = 'Last Name cannot be blank'; }

    else if(!lastNameRegex.test(lastNameInput.value)){
      lastNameError.textContent= 'Please enter letters only';
      lastNameError.style.display='block';
      lastNameInput.classList.add('invalid');

    } else{
      lastNameError.style.display= 'none';
      lastNameInput.classList.remove('invalid');
      lastName.textContent='';
    }
  }

  /*
//validate dob
function validateDOB() {
  const dobInput = document.getElementById('dob');
  const dobError = document.getElementById('dobError');
  const dob = dobInput.value.trim();

  if (dob === '') {
    dobError.textContent = 'Date of birth is required';
  } else {
    dobError.textContent = '';
  }
}

  //validate age
function validateAge() {
  const ageInput = document.getElementById('age');
  const ageError = document.getElementById('ageError');
  const age = ageInput.value.trim();

  if (age === '') {
    ageError.textContent = 'Age is required';
  } else {
    ageError.textContent = '';
  }
}
*/

// Validate DOB and update age
document.addEventListener('DOMContentLoaded', function() {
  const dobInput = document.getElementById('dob');
  const ageInput = document.getElementById('age');
  
  dobInput.addEventListener('input', function() {
      const dobValue = dobInput.value;
      if (dobValue) {
          const dobDate = new Date(dobValue);
          const now = new Date();
          const monthDiff = now - dobDate;
          
          const ageDate = new Date(monthDiff);
          const age = Math.abs(ageDate.getUTCFullYear() - 1970);
          
          ageInput.value = age;
      } else {
          ageInput.value = '';
      }
  });
})
 

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
    
    const confirmPasswordError = document.getElementById('cpasswordError');
    
    // If there are no errors, submit the form
    if (confirmPasswordError.textContent === '') {
      event.target.submit();
    }
  }
  

  //validate for login username
  function validateUsername1() {
    const usernameInput = document.getElementById('username');
    const username = usernameInput.value.trim();
    const usernameErrorSpan = document.getElementById('usernameError');

    const validUsernameRegex = /^[a-zA-Z0-9_]{4,20}$/;

    if (validUsernameRegex.test(username)) {
        usernameErrorSpan.textContent = '';
    } else {
        usernameErrorSpan.textContent = 'contain 4 to 20 characters long(letters, numbers, and underscores.)';
    }
}
//validate for login password
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
        passwordErrorSpan.textContent = 'Atleast 8 characters long(atleast one uppercase,one lowercase, and one digit)';
    }
}


