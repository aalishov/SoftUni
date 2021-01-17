function roadRadar(speed, area) {
    let speedLimit;
    switch (area) {
        case "motorway":
            speedLimit = 130;
            break;
        case "interstate":
            speedLimit = 90;
            break;
        case "city":
            speedLimit = 50;
            break;
        case "residential":
            speedLimit = 20;
            break;
    }

    if (speed <= speedLimit) {
        return `Driving ${speed} km/h in a ${speedLimit} zone`
    }
    else {
        let exceededSpeed = speed - speedLimit;
        let text;
        if (exceededSpeed<=20) {
            text='speeding';
        }else if (exceededSpeed<=40) {
            text='excessive speeding';
        }else{
            text='reckless driving';
        }
        return `The speed is ${exceededSpeed} km/h faster than the allowed speed of ${speedLimit} - ${text}`;
    }
    
}

console.log(roadRadar(40, 'city'));
console.log(roadRadar(21, 'residential'));
console.log(roadRadar(120, 'interstate'));
console.log(roadRadar(200, 'motorway'));