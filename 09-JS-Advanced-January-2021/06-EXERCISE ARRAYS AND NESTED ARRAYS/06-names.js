function solve(arr){
    let result=arr
    .slice(0)
    .sort((a,b)=>a.localeCompare(b))
    .map((name,index, initialArray) =>{
        return `${index+1}.${name}`
    });

    return result.join('\n');
}

console.log(solve(["John", "Bob", "Christina", "Ema"]));