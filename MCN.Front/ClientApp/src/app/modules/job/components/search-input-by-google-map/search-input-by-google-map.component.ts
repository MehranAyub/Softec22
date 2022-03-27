import { AfterViewInit, ChangeDetectionStrategy, Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { GoogleMap } from '@angular/google-maps';
import { MatBottomSheetRef } from '@angular/material/bottom-sheet';
import { Marker } from '../../models/mapService';
// const marker:Marker = {
//   position: {
//     lat: 33.599239344482179,
//     lng: 73.0098210191367093,
//   },
//   title: '',
//   label:{color:'red',text:'text 123'},
//   options: {
//     animation: google==undefined?'':google.maps.Animation.DROP,
//     draggable:true,
//     icon: {
//       url: 'assets/img/PickPin.svg',
//     },
//   },
// };
var placeItem:any={};

@Component({
  selector: 'app-search-input-by-google-map',
  templateUrl: './search-input-by-google-map.component.html',
  styleUrls:['./search-input-by-google-map.component.scss'],
  changeDetection:ChangeDetectionStrategy.OnPush
})
export class SearchInputByGoogleMapComponent implements AfterViewInit {
  
  public pos:google.maps.LatLng;
  private geoCoder;
  constructor(private _bottomSheetRef: MatBottomSheetRef<SearchInputByGoogleMapComponent>){
  }
  ngAfterViewInit(){
    // function initMap(): void {
      const map = new google.maps.Map(
        document.getElementById("map") as HTMLElement,
        {
          center: { lat: 40.749933, lng: -73.98633 },
          zoom: 18,
          mapTypeControl: false,
        }
      );
      this.geoCoder = new google.maps.Geocoder();
      const marker = new google.maps.Marker({
        map,
        anchorPoint: new google.maps.Point(0, -29),
      });
      if(navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function(position) {
          map.setCenter(new google.maps.LatLng(position.coords.latitude,position.coords.longitude));
          marker.setPosition(new google.maps.LatLng(position.coords.latitude,position.coords.longitude));
          marker.setDraggable(true);
          marker.setAnimation(google.maps.Animation.DROP);
          map.setZoom(12);
        });
        }

      const card = document.getElementById("pac-card") as HTMLElement;
      const input = document.getElementById("pac-input") as HTMLInputElement;
      const biasInputElement = document.getElementById(
        "use-location-bias"
      ) as HTMLInputElement;
      const strictBoundsInputElement = document.getElementById(
        "use-strict-bounds"
      ) as HTMLInputElement;
      const options = {
        fields: ["formatted_address", "geometry", "name"],
        strictBounds: false,
        types: ["establishment"],
      };
    
      map.controls[google.maps.ControlPosition.TOP_LEFT].push(card);
    
      const autocomplete = new google.maps.places.Autocomplete(input, options);
    
      // Bind the map's bounds (viewport) property to the autocomplete object,
      // so that the autocomplete requests use the current map bounds for the
      // bounds option in the request.
      autocomplete.bindTo("bounds", map);
    
      const infowindow = new google.maps.InfoWindow();
      const infowindowContent = document.getElementById(
        "infowindow-content"
      ) as HTMLElement;
    
      infowindow.setContent(infowindowContent);
    
     
    
      autocomplete.addListener("place_changed", () => {
        infowindow.close();
        marker.setVisible(false);
    
        const place = autocomplete.getPlace();
    
        if (!place.geometry || !place.geometry.location) {
          // User entered the name of a Place that was not suggested and
          // pressed the Enter key, or the Place Details request failed.
          window.alert("No details available for input: '" + place.name + "'");
          return;
        }
    
        // If the place has a geometry, then present it on a map.
        if (place.geometry.viewport) {
          map.fitBounds(place.geometry.viewport);
        } else {
          map.setCenter(place.geometry.location);
        }

        placeItem=place;
        console.log(placeItem)
        marker.setPosition(place.geometry.location);
        marker.setVisible(true);
        marker.setDraggable(true);
        infowindowContent.children["place-name"].textContent = place.name;
        infowindowContent.children["place-address"].textContent =
          place.formatted_address;
        infowindow.open(map, marker);
      });
    
      // Sets a listener on a radio button to change the filter type on Places
      // Autocomplete.
      function setupClickListener(id, types) {
        const radioButton = document.getElementById(id) as HTMLInputElement;
    
        radioButton.addEventListener("click", () => {
          autocomplete.setTypes(types);
          input.value = "";
        });
      }
    
      setupClickListener("changetype-all", []);
      setupClickListener("changetype-address", ["address"]);
      setupClickListener("changetype-establishment", ["establishment"]);
      setupClickListener("changetype-geocode", ["geocode"]);
      setupClickListener("changetype-cities", ["(cities)"]);
      setupClickListener("changetype-regions", ["(regions)"]);
    
      biasInputElement.addEventListener("change", () => {
        if (biasInputElement.checked) {
          autocomplete.bindTo("bounds", map);
        } else {
          // User wants to turn off location bias, so three things need to happen:
          // 1. Unbind from map
          // 2. Reset the bounds to whole world
          // 3. Uncheck the strict bounds checkbox UI (which also disables strict bounds)
          autocomplete.unbind("bounds");
          autocomplete.setBounds({ east: 180, west: -180, north: 90, south: -90 });
          strictBoundsInputElement.checked = biasInputElement.checked;
        }
    
        input.value = "";
      });
    
      strictBoundsInputElement.addEventListener("change", () => {
        autocomplete.setOptions({
          strictBounds: strictBoundsInputElement.checked,
        });
    
        if (strictBoundsInputElement.checked) {
          biasInputElement.checked = strictBoundsInputElement.checked;
          autocomplete.bindTo("bounds", map);
        }
    
        input.value = "";
      });
    // }

    

    google.maps.event.addListener(marker,'dragend',function(event)
        {
    //console.log(event.latLng.lat());
    // this.placeItem.geometry.location.lat =event.latLng.lat();
    // this.placeItem.geometry.location.lat =event.latLng.lng();
    //console.log(marker.getPosition().lat());
    geocodePosition(marker.getPosition())
    
});

function   geocodePosition(pos) {
  if (navigator.geolocation) {
    let geocoder = new google.maps.Geocoder();
    let latlng = new google.maps.LatLng(pos.lat(), pos.lng());
    let request:any = { latLng: latlng };
    geocoder.geocode(request, (results, status) => {
      if (status == google.maps.GeocoderStatus.OK) {
        console.log(results);
        let result = results[2];
        if (result != null) {
          // this.fillInputs(result.formatted_address);
          placeItem=result;
        } else {
          alert("No address available!");
        }
      }
    });
}
}

  }


 
  Accept(){
    this._bottomSheetRef.dismiss({code:'200',data:placeItem});    
  }
}
