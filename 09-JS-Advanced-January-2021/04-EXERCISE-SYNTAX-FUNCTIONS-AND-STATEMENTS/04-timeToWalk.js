function timeToWalk(steps, footprint, speedKmH) {
    const speed = speedKmH * 1000 / 3600;
    const distance = steps * footprint;


    const rest = Math.floor(distance / 500)*60;
    const time = distance / speed + rest;

    const hours=Math.floor(time/3600).toFixed(0).padStart(2,"0");
    const minutes=Math.floor((time-hours*3600)/60).toFixed().padStart(2,"0");
    const seconds=Math.floor((time-hours*60*60)-minutes*60).toFixed(0).padStart(2,"0");

    return `${hours}:${minutes}:${seconds}`
}

console.log(timeToWalk(4000, 0.60, 5));