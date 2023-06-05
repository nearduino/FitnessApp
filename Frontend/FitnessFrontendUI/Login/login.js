// Get reference to the login form
var loginForm = document.getElementById('loginForm');
loginForm.username.value = "David";
loginForm.password.value = "secretpassword";

  // Attach event listener to form submit event
  loginForm.addEventListener('submit', function(event) {
    // Prevent default form submission
    event.preventDefault();

    // Retrieve form data
    var formData = new FormData(loginForm);

    // Construct HTTP request
    var request = new XMLHttpRequest();
    request.open('POST', 'https://localhost:7108/api/User/login');
    request.setRequestHeader('Content-Type', 'text/json');

    // Handle response
    request.onload = function() {
      if (request.status === 200) {
        // User registration successful
        console.log('User logined successfully');
        // Redirect to another page or perform other actions
        window.location.href = "../index.html";
      } else {
        // User registration failed
        console.error('User login failed');
        alert('Login failed!');
      }
    };

    // Convert form data to JSON
    var jsonData = JSON.stringify(Object.fromEntries(formData));

    // Send HTTP request with JSON data
    request.send(jsonData);
  });