
var Arm = Arm || {
	x: 0,
	y: 0,
	length: 100,
	angle: 0,
/*
	centerAngle:0,
	rotationRange: Math.PI / 4,*/
	parent: null,

	create: function(x, y, length, angle) {
	var obj = Object.create(this);
	obj.init(x, y, length, angle);
	return obj;
},

init: function(x, y, length, angle) {
	this.x = x;
	this.y = y;
	this.length = length;
	this.angle = angle;
},
/*
	create: function(length, centerAngle, rotationRange) {
		var obj = Object.create(this);
		obj.init(length, centerAngle,rotationRange);
		return obj;
	},

	init: function(length, centerAngle, rotationRange) {
		this.length = length;
		this.centerAngle = centerAngle;
		this.rotationRange = rotationRange;
	},

	setPhase: function(phase){
		this.angle = this.centerAngle + Math.sin(phase) * this.rotationRange;
	}, */

	getEndX: function() {
		var angle = this.angle,
			parent = this.parent;
		while(parent) {
			angle += parent.angle;
			parent = parent.parent;
		}
		return this.x + Math.cos(angle) * this.length;
	},

	getEndY: function() {
		var angle = this.angle,
			parent = this.parent;
		while(parent) {
			angle += parent.angle;
			parent = parent.parent;
		}
		return this.y + Math.sin(angle) * this.length;
	},

	render: function(context) {
		context.strokeStyle = "#000000";
		context.lineWidth = 15;
		context.beginPath();
		context.moveTo(this.x, this.y);
		context.lineTo(this.getEndX(), this.getEndY());
		context.stroke();
	}


};
