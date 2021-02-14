class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
    };
 
    addCar( carModel, carNumber ) {
        if (this.capacity > this.vehicles.length) {
            this.vehicles.push({carModel, carNumber, payed: false});
            return `The ${carModel}, with a registration number ${carNumber}, parked.`;
        }
        throw Error ("Not enough parking space.");
    };
 
    removeCar( carNumber ) {
        let found = this.vehicles.find(c => c.carNumber === carNumber);
        if (!found) {
            throw Error ("The car, you're looking for, is not found.");
        }
        if (!found.payed) {
            throw Error (`${found.carNumber} needs to pay before leaving the parking lot.`);
        }
        let index = this.vehicles.indexOf(found);
        this.vehicles.splice(index, 1);
        return `${found.carNumber} left the parking lot.`;
    };
 
    pay( carNumber ) {
        let found = this.vehicles.find(c => c.carNumber === carNumber);
        if (!found) {
            throw Error (`${carNumber} is not in the parking lot.`);
        }
        if (found.payed) {
            throw  Error (`${found.carNumber}'s driver has already payed his ticket.`);
        }
        found.payed = true;
        return `${found.carNumber}'s driver successfully payed for his stay.`;
    };
 
    getStatistics(carNumber) {
        if (!carNumber) {
            let eSlots = this.capacity - this.vehicles.length;
            let result = `The Parking Lot has ${ eSlots } empty spots left.\n`;
            let sorted = this.vehicles.sort((a, b) => a.carModel.localeCompare(b.carModel));
            for (let obj of sorted) {
                result += `${obj.carModel} == ${obj.carNumber} - ${obj.payed ? 'Has payed' : 'Not payed'}\n`;
            }
            return result.trim();
        }
        let found = this.vehicles.find(c => c.carNumber === carNumber);
        return `${found.carModel} == ${found.carNumber} - ${found.payed ? 'Has payed' : 'Not payed'}`;
    }
}