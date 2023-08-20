 document.addEventListener('DOMContentLoaded', function() {

  const stateDropdown = document.getElementById('state');
  const cityDropdown = document.getElementById('city');

  // Define city options for each state
    const cityOptions = {
      AndhraPradesh: ['Vishakapattanam', 'Vijayawada', 'Tirupati'],
      Goa: ['Vasco', 'Ponda', 'Panaji'],
      Karnataka: ['Bangalore', 'Udupi', 'Tumkur'],
      Kerala: ['Kochi', 'Trivandrum', 'Kottayam'],
      TamilNadu: ['Chennai', 'Madurai', 'Coimbatore']
    };

    stateDropdown.addEventListener('change', function() {
      const selectedState = stateDropdown.value;
      const cities = cityOptions[selectedState] || [];

      cityDropdown.innerHTML = '<option value="none">Select a city</option>';

      cities.forEach(city => {
          const option = document.createElement('option');
          option.value = city.toLowerCase().replace(' ', '');
          option.textContent = city;
          cityDropdown.appendChild(option);
      });

      // Show or hide the city dropdown based on the selected state
      cityDropdown.style.display = cities.length > 0 ? 'block' : 'none';
    });
  });
