window.onload = function() {
	var canvas = document.getElementById("canvas"),
	context = canvas.getContext("2d"),
	width = canvas.width = window.innerWidth,
	height = canvas.height = window.innerHeight;

	/*
	var walk = Walk.create(width / 2, height / 2, 50, 0);

	walk.addArm(200, Math.PI/2, Math.PI/4);
	walk.addArm(180,0.87,0.87);
	*/

//Original length was 100
	var arm = Arm.create(width / 2, height / 2, 50, 0),
		angle = 0,
		arm2 = Arm.create(arm.getEndX(), arm.getEndY(), 50, 1.3),
		arm3 = Arm.create(arm2.getEndX(), arm2.getEndY(), 50, 1.3)
	//	arm4 = Arm.create(arm3.getEndX(), arm3.getEndY(), 100, 1.3)

//x, y
	var leg = Leg.create(width / 5, height / 2, 50, 0),
		angle = 0,
		leg2 = Leg.create(leg.getEndX(), leg.getEndY(), 50, 0),
		leg3 = Leg.create(leg2.getEndX(), leg2.getEndY(), 50, 0)


	arm2.parent = arm;
	arm3.parent = arm2;
	//arm4.parent = arm3;
	leg2.parent = leg;
	leg3.parent = leg2;

	update();

	function update() {
		//NEED THIS LINE SO THAT DOESN'T DO LEG ART!
		context.clearRect(0, 0, width, height);
		/*
		walk.update();
		walk.render(context);*/

		arm.angle = Math.sin(angle) * 1.8;  //1.2 og value
		arm2.angle = Math.cos(angle * .2) * .92; //.5   .92 og values
		arm3.angle = Math.sin(angle * .5) * 1.34; //1.5 1.34
	//	arm4.angle = Math.sin(angle * 1.5) * 1.34;


//NEGATIVE OF ABOVE VALUES CREATES OUT OF PHASE LEGS:

	leg.angle = Math.sin(angle) * -1.8;  //1.2 og value
	leg2.angle = Math.cos(angle * -.2) * -.92; //.5   .92 og values
	leg3.angle = Math.sin(angle * -.5) * -1.34; //1.5 1.34

		arm2.x = arm.getEndX();
		arm2.y = arm.getEndY();
		arm3.x = arm2.getEndX();
		arm3.y = arm2.getEndY();

		leg2.x = leg.getEndX();
		leg2.y = leg.getEndY();
		leg3.x = leg2.getEndX();
		leg3.y = leg2.getEndY();
		//arm4.x = arm3.getEndX();
		//arm4.y = arm3.getEndY();

		angle += 0.05;
		arm.render(context);
		arm2.render(context);
		arm3.render(context);
		leg.render(context);
		leg2.render(context);
		leg3.render(context);
	//	arm4.render(context);
		requestAnimationFrame(update);
	}
}
