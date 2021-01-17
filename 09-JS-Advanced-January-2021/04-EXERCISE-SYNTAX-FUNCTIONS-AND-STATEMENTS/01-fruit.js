function fruit(fruit,weight,price) {
    weight/=1000;
    let money=weight*price;
    return `I need $${money.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`
}

console.log(fruit('orange', 2500, 1.80));