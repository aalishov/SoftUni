function solve(input){
    let result=[];
    while (input.length) {
        let  hero=input.shift();
        let[name,level,itemString]=hero.split(' / ');
        level =Number(level);
        const items=itemString?itemString.split(', '):[];
        result.push({name,level,items});;
    }
    return JSON.stringify(result);
}

console.log(solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
));
console.log(solve(['Jake / 1000 / Gauss, HolidayGrenade']));