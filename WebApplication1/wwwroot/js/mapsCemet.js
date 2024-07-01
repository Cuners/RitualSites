ymaps.ready(init);

function init() {
    var myMap = new ymaps.Map('map', {
        center: [55.818128, 49.098001],
        zoom: 10
    });

    var markers = [];

    var addresses = [
        'Казань ул. Мамадышский тракт, Самосыровское кладбище',
        'Казань, кладбище Киндери',
        'Казань ул. Пригородная 1',
        'Казань ул. Песочная 1а',
        'пос.Дербышки ул. Прибольничная 2',
        'Казань ул. Владимирская 1-я 42Б',
        'Казань ул. Новосельская 64',
        'Казань, Архангельское кладбище',
        'Казань ул. Окольная',
        'Казань ул. Машинистов',
        'Казань ул. Привокзальная',
        'Казань ул. Николая Ершова, д. 25',
        'Юдинское кладбище',
        'Казань ул. Привокзальная Красная Горка',
        'Казань, Мусульманское кладбище'
    ];

    addresses.forEach(function (address) {
        addMarker(address);
    });

    function addMarker(address) {
        ymaps.geocode(address, {
            results: 1
        }).then(function (res) {
            var firstGeoObject = res.geoObjects.get(0);

            if (firstGeoObject) {
                var coords = firstGeoObject.geometry.getCoordinates();
                firstGeoObject.options.set('preset', 'islands#darkBlueDotIconWithCaption');
                firstGeoObject.properties.set('iconCaption', firstGeoObject.getAddressLine());

                myMap.geoObjects.add(firstGeoObject);

                // Сохранение координат метки
                markers.push({
                    address: address,
                    coords: coords
                });
            } else {
                console.log('Адрес не найден: ', address);
            }
        }).catch(function (err) {
            console.log('Ошибка геокодирования: ', err);
        });
    }

    document.querySelectorAll('.custom-button').forEach(function (button) {
        button.addEventListener('click', function () {
            var address = this.getAttribute('data-address');
            focusOnMarker(address);
        });
    });

    function focusOnMarker(address) {
        for (var i = 0; i < markers.length; i++) {
            if (markers[i].address === address) {
                myMap.setCenter(markers[i].coords, 16, {
                    checkZoomRange: true
                });
                break;
            }
        }
    }
}