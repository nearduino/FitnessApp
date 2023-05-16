const searchInput = document.getElementById('search-input');

searchInput.addEventListener('keydown', function(event) {
    if (event.key === 'Enter') {
      event.preventDefault();
      document.getElementById('search-form').submit();
    }
  });