// Autofill the form fields
var form = document.getElementById("registerForm");
form.username.value = "David";
form.email.value = "david@example.com";
form.password.value = "secretpassword";

  // Get reference to the register form
var registerForm = document.getElementById('registerForm');
registerForm.username.value = "David";
registerForm.email.value = "david@example.com";
registerForm.password.value = "secretpassword";

  // Attach event listener to form submit event
  registerForm.addEventListener('submit', function(event) {
    // Prevent default form submission
    event.preventDefault();

    // Retrieve form data
    var formData = new FormData(registerForm);

    // Construct HTTP request
    var request = new XMLHttpRequest();
    request.open('POST', 'https://localhost:7108/api/User');
    request.setRequestHeader('Content-Type', 'text/json');

    // Handle response
    request.onload = function() {
      if (request.status === 200) {
        // User registration successful
        console.log('User registered successfully');
        // Redirect to another page or perform other actions
        window.location.href = "../index.html";
      } else {
        // User registration failed
        console.error('User registration failed');
        alert('Registration failed!');
      }
    };

    // Convert form data to JSON
    var jsonData = JSON.stringify(Object.fromEntries(formData));

    // Send HTTP request with JSON data
    request.send(jsonData);
  });