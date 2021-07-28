$(document).ready(function() {
    'use strict';
    paper.install(window);


    paper.setup(document.getElementById('mainCanvas'));

    // draw a circle
    var circle = new paper.Path.Circle(new paper.Point(100, 100), 50);
    circle.fillColor = 'black';
    circle.strokeColor = 'black';
    circle.strokeWidth = 2;
    circle.name = 'circle';
    circle.onMouseDown = function() {
        console.log('circle onMouseDown');
    };
    circle.onMouseUp = function() {
        console.log('circle onMouseUp');
    };
    circle.onMouseMove = function() {
        console.log('circle onMouseMove');
    };



    var c;
    for (var x = 25; x < 400; x += 50) {
        for (var y = 25; y < 400; y += 50) {
            c = Shape.Circle(x, y, 20);
            c.fillColor = 'green';
        }
    }

    var a = new Class01();
    a.x = 100;




    paper.view.draw();

});


// define a sample class with S name
class Class01 {
    constructor(x, y, r) {
        this.x = x;
        this.y = y;
        this.r = r;
        this.fillColor = 'red';
        this.strokeColor = 'black';
        this.strokeWidth = 1;
    }

    // define a method with S name
    ali() {
        console.log('ali');
    }

    Sort() {

    }
}