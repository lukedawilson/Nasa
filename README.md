# Nasa
Takes two NASA datasets (the International Space Station location, and exoplanet data),
and overlays them on Google Earth and Google Sky, respectively; written in C#/ASP.NET.

This was based on an interactive session given as part of Trayport's internal employee
tech talk series.

## Mars weather API

http://marsweather.ingenology.com/ (e.g. http://marsweather.ingenology.com/v1/archive/)

## ExoAPI

http://exoapi.com/ (e.g.  http://exoapi.com/api/skyhook/planets/search?habitable=1)

## ISS location API

http://open-notify.org/Open-Notify-API/ISS-Location-Now/ (e.g. http://api.open-notify.org/iss-now.json)

## Chart API

```javascript
google.load('visualization', '1.0', { 'packages': ['corechart'] });
google.setOnLoadCallback(function() {
   $.ajax({
      url: "@Url.Action("HttpRequestSync", new { url = api_call })"
   }).success(function_to_render_data);
});
```

https://developers.google.com/chart/

https://developers.google.com/chart/interactive/docs/gallery/barchart

## Earth API

```javascript
var ge;
google.load("earth", "1", { "other_params": "sensor=false" });

function init() { google.earth.createInstance('map3d', initCB); }

function initCB(instance) {
   ge = instance;
   ge.getWindow().setVisibility(true);

   (Make call to api, call showMap with returned data) 
}
      
function showMap(data) {
   ge.getOptions().setMapType(map_type);

   setTimeout(function () {
      (Parse data here)
      
      // Create location object
      var lookAt = ge.getView().copyAsLookAt(ge.ALTITUDE_RELATIVE_TO_GROUND);
      lookAt.setLatitude(some_latitude);
      lookAt.setLongitude(some_longitude);

      // Zoom to point
      var oldFlyToSpeed = ge.getOptions().getFlyToSpeed();
      ge.getOptions().setFlyToSpeed(.2);  // Slow down the camera flyTo speed.
      ge.getView().setAbstractView(lookAt);
      ge.getOptions().setFlyToSpeed(oldFlyToSpeed);
  }, 1000);  // Start the zoom-in after one second.
}

google.setOnLoadCallback(init);
```

http://www.google.com/earth/explore/products/plugin.html

https://developers.google.com/earth/documentation/index

https://developers.google.com/earth/documentation/sky_mars_moon

http://earth-api-samples.googlecode.com/svn/trunk/examples/placemark-point.html

http://earth-api-samples.googlecode.com/svn/trunk/examples/event-placemark.html

## HTTP request helper

```javascript
$.ajax({ 
   url: "@Url.Action("HttpRequestSync", new { url = some_url })"
}).success(some_function);
```

## Parse JSON response

```javascript
JSON.parse(data)
```

## Create a placemark (pin)

```javascript
var placemark = ge.createPlacemark('');
ge.getFeatures().appendChild(placemark);

var point = ge.createPoint('');
point.setLatitude(some_latitude);
point.setLongitude(some_longitude);
placemark.setGeometry(point);
```
