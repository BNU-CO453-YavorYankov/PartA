/* Display the div for the units type based on select element value*/
function displayUnitsDiv() {
    var select = document.getElementById('select-units-type').value;

    var imperialDiv = document.getElementById('imperial-units');
    var metricDiv = document.getElementById('metric-units');

    if (select === 'please select unit type') {
        imperialDiv.style.display = 'none';
        metricDiv.style.display = 'none';
    }
    else if (select === '1')
    {
        imperialDiv.style.display = 'block';
        metricDiv.style.display = 'none';
    }
    else if (select === '2') {
        imperialDiv.style.display = 'none';
        metricDiv.style.display = 'block';
    }
}