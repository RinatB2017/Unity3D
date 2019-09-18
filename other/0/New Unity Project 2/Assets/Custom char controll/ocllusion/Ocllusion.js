// occlusion scrip it self.. wery simple and basic, for learning or use in unity indie for 2d games :) by Arvydas Andrius (arWe2793) ;).
// https://www.youtube.com/user/SuperKREPSINIS?spfreload=10  // my chanell

var content : GameObject; // CONTENT DO SIABLE AND ENABLE.

function Start (){
	content.SetActive(false); // disable on start, better to leave this, or disable manualy.
}

function OnTriggerEnter2D (other : Collider2D) {
	if(other.tag == "PlayerCollider"){ // tag, need to add tag for 2D trigger and attack it on camera.
		content.SetActive (true); // content obj will be disabled and enabled, attack rigidbody2dD componnet on it! then parent some sprites or anything.
}}
function OnTriggerExit2D (other : Collider2D) {
	if(other.tag == "PlayerCollider"){
		content.SetActive(false);
}}