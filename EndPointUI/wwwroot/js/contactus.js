$(document).ready(function () {

    let lat = parseFloat(document.getElementById("lat").value);
    let lon = parseFloat(document.getElementById("lon").value);


   
    var map = L.map('contact-map').setView([lat, lon], 15);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    L.marker([lat, lon]).addTo(map)
       
        .openPopup();
    map.invalidateSize();

});