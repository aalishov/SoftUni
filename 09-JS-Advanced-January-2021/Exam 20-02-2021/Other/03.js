const expect = require('chai').expect;
const numberOperations = require('./numberOperations');
 
describe('Number Operations Tests', function() {
    describe('powNumber', function() {
        it('should return correct result with positive number', function() {
            let number = 5;
            let expectedNumber = number * number;
 
            let actualNumber = numberOperations.powNumber(number);
 
            expect(expectedNumber).to.equal(actualNumber);
        });
 
        it('should return correct result with 0', function() {
            let number = 0;
            let expectedNumber = number * number;
 
            let actualNumber = numberOperations.powNumber(number);
 
            expect(expectedNumber).to.equal(actualNumber);
        });
 
        it('should return correct result with negative number', function() {
            let number = -5;
            let expectedNumber = number * number;
 
            let actualNumber = numberOperations.powNumber(number);
 
            expect(expectedNumber).to.equal(actualNumber);
        });
    });
 
    describe('numberChecker', function() {
        it('should throw an error when not a number is passed', function() {
            let input = 'This is not a number';
 
            expect(() => numberOperations.numberChecker(input)).to.throw('The input is not a number!');
        });
 
        it('should return correct message with number less than 100', function() {
            let input = 50;
            let expectedMessage = 'The number is lower than 100!';
 
            let actualMessage=  numberOperations.numberChecker(input);
 
            expect(expectedMessage).to.equal(actualMessage);
        });
 
        it('should return correct message with number bigger than 100', function() {
            let input = 150;
            let expectedMessage = 'The number is greater or equal to 100!';
 
            let actualMessage=  numberOperations.numberChecker(input);
 
            expect(expectedMessage).to.equal(actualMessage);
        });
 
        it('should return correct message with 100', function() {
            let input = 100;
            let expectedMessage = 'The number is greater or equal to 100!';
 
            let actualMessage=  numberOperations.numberChecker(input);
 
            expect(expectedMessage).to.equal(actualMessage);
        });
    });
 
    describe('sumArrays', function() {
        it('should return sum of arrays elements', function() {
            let shorterArray = [5, 10, 15];
            let longerArray = [20, 30, 40, 50];
 
            let expectedArray = [25, 40, 55, 50];
 
            let actualArray = numberOperations.sumArrays(shorterArray, longerArray);
 
            expect(expectedArray).to.deep.equal(actualArray);
        });
    });
});