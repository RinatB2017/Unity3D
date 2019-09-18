// this script leak some performance, to be sure ours ocllusion script realy working

function Update () {
PlayerPrefs.SetInt("performance leaker", 1);  // in update this function weri BAD. so i will place it here
PlayerPrefs.SetInt("performance leaker", 1); // 2x
PlayerPrefs.SetInt("performance leaker", 1); // 3x
PlayerPrefs.SetInt("performance leaker", 1); // 4x
PlayerPrefs.SetInt("performance leaker", 1); // 5x
PlayerPrefs.SetInt("performance leaker", 1); // 6x
PlayerPrefs.SetInt("performance leaker", 1); // 7x
PlayerPrefs.SetInt("performance leaker", 1); // 8x
PlayerPrefs.SetInt("performance leaker", 1); // 9x
PlayerPrefs.SetInt("performance leaker", 1); // 10x
PlayerPrefs.SetInt("performance leaker", 1); // 11x
PlayerPrefs.SetInt("performance leaker", 1); // 12x
PlayerPrefs.SetInt("performance leaker", 1); // 13x
PlayerPrefs.SetInt("performance leaker", 1); // 14x
PlayerPrefs.SetInt("performance leaker", 1); // 15x
PlayerPrefs.SetInt("performance leaker", 1); // 16x
PlayerPrefs.SetInt("performance leaker", 1); // 17x
PlayerPrefs.SetInt("performance leaker", 1); // 18x
PlayerPrefs.SetInt("performance leaker", 1); // 19x
}