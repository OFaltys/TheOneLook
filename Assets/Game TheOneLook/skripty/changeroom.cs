using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeroom : MonoBehaviour {

	private string mistnost;

	public Text textik;

	private string ze_zdi = "B";

	public GameObject na_zdi_A, na_zdi_B, na_zdi_C, na_zdi_D;

	public GameObject dira;

	public GameObject[] zdi;
	int[] cislo_mistnosti = {0, 5, 2, 3}; 
	public int momentalne_mistnost = 0;
	int momentalne_objekt = 0;
	int z_mistnosti = 0;
	//public NazvyZnacekObjekt[];

	// Use this for initialization
	void Start () {
		
		mistnost = "zed2";	//zed B prvne vidi

	}
		

	int najezdDoPrava(int skutecne_odkud, int objekt_minule_mistnosti){

		objekt_minule_mistnosti = objekt_minule_mistnosti > 1 ? -1 : objekt_minule_mistnosti + 1 ;
		nastavMistnost (skutecne_odkud, objekt_minule_mistnosti);	
		return objekt_minule_mistnosti;
	}

	void nastavMistnost(int skutecne_odkud ,int podle){
		for (int i = 0; i < 4; i++) 
			if(i == podle)
			zdi[skutecne_odkud].transform.GetChild(i).gameObject.SetActive (true);
		else
			zdi[skutecne_odkud].transform.GetChild(i).gameObject.SetActive (false);	
	}
		
	/*int najezdDoLeva(int skutecne_odkud, int objekt_minule_mistnosti){

		objekt_minule_mistnosti = objekt_minule_mistnosti < 2 ? objekt_minule_mistnosti + 2 : objekt_minule_mistnosti - 2;
		print ("cislo mistnosti " + objekt_minule_mistnosti);
		for (int i = 0; i < 5; i++) 
			if(i == objekt_minule_mistnosti)
				zdi[skutecne_odkud].transform.GetChild(i).gameObject.SetActive (true);
			else
				zdi[skutecne_odkud].transform.GetChild(i).gameObject.SetActive (false);		
		return objekt_minule_mistnosti;
	}*/


	void OnTriggerEnter(Collider other) {


			// zed A do zed D leva
			// zed A do zed B prava
		if (other.CompareTag ("zedA")) {
			print ("zedA");

			if (momentalne_mistnost == 1)
				cislo_mistnosti[0] = najezdDoPrava (momentalne_mistnost, cislo_mistnosti[0]);
			if (momentalne_mistnost == 7)
				nastavMistnost (3, 1);
			if (momentalne_mistnost == 8)
				nastavMistnost (3, 3);
			momentalne_mistnost = 0;

		}

		if (other.CompareTag ("zedB")) {
			print ("zedB");

			if (momentalne_mistnost == 2)
				cislo_mistnosti[1] = najezdDoPrava (momentalne_mistnost, cislo_mistnosti[1]);
			if (momentalne_mistnost == 7)
				nastavMistnost (3, 3);
			if (momentalne_mistnost == 8)
				nastavMistnost (3, 1);
			momentalne_mistnost = 1;

		}

		if (other.CompareTag ("zedC")) {
			print ("zedC");

			if (momentalne_mistnost == 3)
				cislo_mistnosti[2] = najezdDoPrava (momentalne_mistnost, cislo_mistnosti[2]);
			if (momentalne_mistnost == 7)
				nastavMistnost (3, 2);
			if (momentalne_mistnost == 8)
				nastavMistnost (3, 3);
			momentalne_mistnost = 2;

		}

		if (other.CompareTag ("zedD")) {
			print ("zedD");

			if (momentalne_mistnost == 0)
				cislo_mistnosti[3] = najezdDoPrava (momentalne_mistnost, cislo_mistnosti[3]);
			if (momentalne_mistnost == 7)
				nastavMistnost (3, 3);
			if (momentalne_mistnost == 8)
				nastavMistnost (3, 1);
			momentalne_mistnost = 3;

		}

		if (other.CompareTag("zem")) {
			print("zem");
			nastavMistnost (3, 5);
			nastavMistnost (1, 4);

			momentalne_mistnost = 7;
		}

		if (other.CompareTag("strop")) {
			print("strop");
				dira.SetActive (false);
			nastavMistnost (2, 5);
			momentalne_mistnost = 8;
		}
			//ze_zdi = "S";

		/*
			// zed A do zed D leva
			// zed A do zed B prava
			if (other.CompareTag("zedA")) {
			print("zedA");

		

			if (ze_zdi == "B") {
				if (mistnost == "zed1") {
					mistnost = "zed2";
					na_zdi_A.transform.GetChild (0).gameObject.SetActive(  true);
					na_zdi_A.transform.GetChild (1).gameObject.SetActive (   false);
					na_zdi_A.transform.GetChild (2).gameObject.SetActive (   false);
					na_zdi_A.transform.GetChild (3).gameObject.SetActive (   false);
				}
				else if (mistnost == "zed2") {
					mistnost = "zed3";
					na_zdi_A.transform.GetChild (0).gameObject.SetActive  (false);
					na_zdi_A.transform.GetChild (1).gameObject.SetActive  (true);
					na_zdi_A.transform.GetChild (2).gameObject.SetActive  (false);
					na_zdi_A.transform.GetChild (3).gameObject.SetActive  (false);
				}
				else if (mistnost == "zed3") {
					mistnost = "zed4";
					na_zdi_A.transform.GetChild (0).gameObject.SetActive ( false);
					na_zdi_A.transform.GetChild (1).gameObject.SetActive ( false);
					na_zdi_A.transform.GetChild (2).gameObject.SetActive ( true);
					na_zdi_A.transform.GetChild (3).gameObject.SetActive ( false);
				}
				else if (mistnost == "zed4") {
					mistnost = "zed1";
					na_zdi_A.transform.GetChild (0).gameObject.SetActive ( false);
					na_zdi_A.transform.GetChild (1).gameObject.SetActive ( false);
					na_zdi_A.transform.GetChild (2).gameObject.SetActive ( false);
					na_zdi_A.transform.GetChild (3).gameObject.SetActive ( false);
				}
			}
			if (ze_zdi == "D") {
				if (mistnost == "zed1") {
					mistnost = "zed3";
					na_zdi_A.transform.GetChild (0).gameObject.SetActive  (false);
					na_zdi_A.transform.GetChild (1).gameObject.SetActive  (true);
					na_zdi_A.transform.GetChild (2).gameObject.SetActive  (false);
					na_zdi_A.transform.GetChild (3).gameObject.SetActive  (false);
				}
				else if (mistnost == "zed2") {
					mistnost = "zed4";
					na_zdi_A.transform.GetChild (0).gameObject.SetActive ( false);
						na_zdi_A.transform.GetChild (1).gameObject.SetActive ( false);
							na_zdi_A.transform.GetChild (2).gameObject.SetActive ( true);
								na_zdi_A.transform.GetChild (3).gameObject.SetActive ( false);
				}
				else if (mistnost== "zed3") {
					mistnost = "zed1";
					na_zdi_A.transform.GetChild (0).gameObject.SetActive (false);
						na_zdi_A.transform.GetChild (1).gameObject.SetActive  (false);
							na_zdi_A.transform.GetChild (2).gameObject.SetActive (false);
								na_zdi_A.transform.GetChild (3).gameObject.SetActive  (false);
				}
				else if (mistnost == "zed4") {
					mistnost = "zed2";
					na_zdi_A.transform.GetChild (0).gameObject.SetActive  (true);
					na_zdi_A.transform.GetChild (1).gameObject.SetActive  (false);
					na_zdi_A.transform.GetChild (2).gameObject.SetActive ( false);
					na_zdi_A.transform.GetChild (3).gameObject.SetActive  (false);
				}
			}

			if (ze_zdi == "Z") {
				mistnost = "zed4";
				na_zdi_A.transform.GetChild (0).gameObject.SetActive ( false);
				na_zdi_A.transform.GetChild (1).gameObject.SetActive ( false);
				na_zdi_A.transform.GetChild (2).gameObject.SetActive ( false);
				na_zdi_A.transform.GetChild (3).gameObject.SetActive ( true);

				textik.text = "Našel jsi cestu ven ke světlu. Vyhral jsi!";
			}

			*/
			/*
			if (ze_zdi == "Z") {
				if (mistnost == "zed1" || mistnost == "zed2" || mistnost == "zed4") {
					mistnost = "zem";
				} else if (mistnost == "zed3") {
					mistnost = "zem_zkouska";
					dira.SetActive (false);
				} else if (mistnost == "zem") {
					mistnost = "zed4";
				}
			}*/

			/*
			ze_zdi = "A";
			}

			// zed B do zed A leva
			// zed B do zed C prava
			if (other.CompareTag("zedB")) {
			print("zedB");

			if (ze_zdi == "C") {
				if (mistnost == "zed1") {
					mistnost = "zed2";
					na_zdi_B.transform.GetChild (0).gameObject.SetActive ( true);
					na_zdi_B.transform.GetChild (1).gameObject.SetActive (false);
					na_zdi_B.transform.GetChild (2).gameObject.SetActive ( false);
					na_zdi_B.transform.GetChild (3).gameObject.SetActive (false);
				}
				else if (mistnost == "zed2") {
					mistnost = "zed3";
					na_zdi_B.transform.GetChild (0).gameObject.SetActive (false);
					na_zdi_B.transform.GetChild (1).gameObject.SetActive (true);
					na_zdi_B.transform.GetChild (2).gameObject.SetActive ( false);
					na_zdi_B.transform.GetChild (3).gameObject.SetActive ( false);
				}
				else if (mistnost == "zed3") {
					mistnost = "zed4";
					na_zdi_B.transform.GetChild (0).gameObject.SetActive ( false);
					na_zdi_B.transform.GetChild (1).gameObject.SetActive ( false);
					na_zdi_B.transform.GetChild (2).gameObject.SetActive (true);
					na_zdi_B.transform.GetChild (3).gameObject.SetActive ( false);
				}
				else if (mistnost == "zed4") {
					mistnost = "zed1";
					na_zdi_B.transform.GetChild (0).gameObject.SetActive( false);
					na_zdi_B.transform.GetChild (1).gameObject.SetActive (false);
					na_zdi_B.transform.GetChild (2).gameObject.SetActive ( false);
					na_zdi_B.transform.GetChild (3).gameObject.SetActive (false);
				}
			}
			if (ze_zdi == "A") {
				if (mistnost == "zed1") {
					mistnost = "zed3";
					na_zdi_B.transform.GetChild (0).gameObject.SetActive (false);
					na_zdi_B.transform.GetChild (1).gameObject.SetActive (true);
					na_zdi_B.transform.GetChild (2).gameObject.SetActive ( false);
					na_zdi_B.transform.GetChild (3).gameObject.SetActive (false);
				}
				else if (mistnost == "zed2") {
					mistnost = "zed4";
					na_zdi_B.transform.GetChild (0).gameObject.SetActive (false);
					na_zdi_B.transform.GetChild (1).gameObject.SetActive ( false);
					na_zdi_B.transform.GetChild (2).gameObject.SetActive ( true);
					na_zdi_B.transform.GetChild (3).gameObject.SetActive (false);
				}
				else if (mistnost== "zed3") {
					mistnost = "zed1";
					na_zdi_B.transform.GetChild (0).gameObject.SetActive ( false);
					na_zdi_B.transform.GetChild (1).gameObject.SetActive ( false);
					na_zdi_B.transform.GetChild (2).gameObject.SetActive (false);
					na_zdi_B.transform.GetChild (3).gameObject.SetActive ( false);
				}
				else if (mistnost == "zed4") {
					mistnost = "zed2";
					na_zdi_B.transform.GetChild (0).gameObject.SetActive (true);
					na_zdi_B.transform.GetChild (1).gameObject.SetActive ( false);
					na_zdi_B.transform.GetChild (2).gameObject.SetActive (false);
					na_zdi_B.transform.GetChild (3).gameObject.SetActive ( false);
				}
			}

			if (ze_zdi == "Z") {
				mistnost = "zed3";
				na_zdi_A.transform.GetChild (0).gameObject.SetActive ( false);
				na_zdi_A.transform.GetChild (1).gameObject.SetActive ( true);
				na_zdi_A.transform.GetChild (2).gameObject.SetActive ( false);
				na_zdi_A.transform.GetChild (3).gameObject.SetActive ( false);
			}*/
			/*
			if (ze_zdi == "Z") {
				if (mistnost == "zed1" || mistnost == "zed2" || mistnost == "zed4") {
					mistnost = "zem";
				} else if (mistnost == "zed3") {
					mistnost = "zem_zkouska";
					dira.SetActive (false);
				} else if (mistnost == "zem") {
					mistnost = "zed3";
				}
			}*/

			/*
			ze_zdi = "B";
		}

			// zed C do zed B leva
			// zed C do zed D prava
			if (other.CompareTag("zedC")) {
			print("zedC");

			if (ze_zdi == "B") {
				if (mistnost == "zed1") {
					mistnost = "zed2";
					na_zdi_C.transform.GetChild (0).gameObject.SetActive ( true);
					na_zdi_C.transform.GetChild (1).gameObject.SetActive ( false);
					na_zdi_C.transform.GetChild (2).gameObject.SetActive ( false);
					na_zdi_C.transform.GetChild (3).gameObject.SetActive (false);
				}
				else if (mistnost == "zed2") {
					mistnost = "zed3";
					na_zdi_C.transform.GetChild (0).gameObject.SetActive ( false);
					na_zdi_C.transform.GetChild (1).gameObject.SetActive (true);
					na_zdi_C.transform.GetChild (2).gameObject.SetActive ( false);
					na_zdi_C.transform.GetChild (3).gameObject.SetActive ( false);
				}
				else if (mistnost == "zed3") {
					mistnost = "zed4";
					na_zdi_C.transform.GetChild (0).gameObject.SetActive ( false);
					na_zdi_C.transform.GetChild (1).gameObject.SetActive ( false);
					na_zdi_C.transform.GetChild (2).gameObject.SetActive ( true);
					na_zdi_C.transform.GetChild (3).gameObject.SetActive (false);
				}
				else if (mistnost == "zed4") {
					mistnost = "zed1";
					na_zdi_C.transform.GetChild (0).gameObject.SetActive (false);
					na_zdi_C.transform.GetChild (1).gameObject.SetActive ( false);
					na_zdi_C.transform.GetChild (2).gameObject.SetActive ( false);
					na_zdi_C.transform.GetChild (3).gameObject.SetActive (false);
				}
			}
			if (ze_zdi == "D") {
				if (mistnost == "zed1") {
					mistnost = "zed3";
					na_zdi_C.transform.GetChild (0).gameObject.SetActive ( false);
					na_zdi_C.transform.GetChild (1).gameObject.SetActive (true);
					na_zdi_C.transform.GetChild (2).gameObject.SetActive (false);
					na_zdi_C.transform.GetChild (3).gameObject.SetActive (false);
				}
				else if (mistnost == "zed2") {
					mistnost = "zed4";
					na_zdi_C.transform.GetChild (0).gameObject.SetActive ( false);
					na_zdi_C.transform.GetChild (1).gameObject.SetActive ( false);
					na_zdi_C.transform.GetChild (2).gameObject.SetActive ( true);
					na_zdi_C.transform.GetChild (3).gameObject.SetActive ( false);
				}
				else if (mistnost== "zed3") {
					mistnost = "zed1";
					na_zdi_C.transform.GetChild (0).gameObject.SetActive ( false);
					na_zdi_C.transform.GetChild (1).gameObject.SetActive (false);
					na_zdi_C.transform.GetChild (2).gameObject.SetActive ( false);
					na_zdi_C.transform.GetChild (3).gameObject.SetActive ( false);
				}
				else if (mistnost == "zed4") {
					mistnost = "zed2";
					na_zdi_C.transform.GetChild (0).gameObject.SetActive ( true);
					na_zdi_C.transform.GetChild (1).gameObject.SetActive ( false);
					na_zdi_C.transform.GetChild (2).gameObject.SetActive ( false);
					na_zdi_C.transform.GetChild (3).gameObject.SetActive ( false);
				}
			}

			if (ze_zdi == "Z") {
				mistnost = "zed2";
				na_zdi_C.transform.GetChild (0).gameObject.SetActive ( true);
				na_zdi_C.transform.GetChild (1).gameObject.SetActive ( false);
				na_zdi_C.transform.GetChild (2).gameObject.SetActive ( false);
				na_zdi_C.transform.GetChild (3).gameObject.SetActive ( false);
			}*/
			/*
			if (ze_zdi == "Z") {
				if (mistnost == "zed1" || mistnost == "zed2" || mistnost == "zed4") {
					mistnost = "zem";
				} else if (mistnost == "zed3") {
					mistnost = "zem_zkouska";
					dira.SetActive (false);
				} else if (mistnost == "zem") {
					mistnost = "zed2";
				}
			}
					*//*
			ze_zdi = "C";
		}

			// zed D do zed C leva
			// zed D do zed A prava
			if (other.CompareTag("zedD")) {
			print("zedD");

				if (ze_zdi == "A") {
					if (mistnost == "zed1") {
						mistnost = "zed2";
					na_zdi_D.transform.GetChild (0).gameObject.SetActive ( true);
					na_zdi_D.transform.GetChild (1).gameObject.SetActive ( false);
					na_zdi_D.transform.GetChild (2).gameObject.SetActive ( false);
					na_zdi_D.transform.GetChild (3).gameObject.SetActive (false);
					}
					else if (mistnost == "zed2") {
						mistnost = "zed3";
					na_zdi_D.transform.GetChild (0).gameObject.SetActive ( false);
					na_zdi_D.transform.GetChild (1).gameObject.SetActive ( true);
					na_zdi_D.transform.GetChild (2).gameObject.SetActive ( false);
					na_zdi_D.transform.GetChild (3).gameObject.SetActive ( false);
					}
					else if (mistnost == "zed3") {
						mistnost = "zed4";
					na_zdi_D.transform.GetChild (0).gameObject.SetActive (false);
					na_zdi_D.transform.GetChild (1).gameObject.SetActive ( false);
					na_zdi_D.transform.GetChild (2).gameObject.SetActive(true);
					na_zdi_D.transform.GetChild (3).gameObject.SetActive ( false);
					}
					else if (mistnost == "zed4") {
						mistnost = "zed1";
					na_zdi_D.transform.GetChild (0).gameObject.SetActive ( false);
					na_zdi_D.transform.GetChild (1).gameObject.SetActive ( false);
					na_zdi_D.transform.GetChild (2).gameObject.SetActive (false);
					na_zdi_D.transform.GetChild (3).gameObject.SetActive ( false);
					}}
				if (ze_zdi == "C") {
						if (mistnost == "zed1") {
							mistnost = "zed3";
					na_zdi_D.transform.GetChild (0).gameObject.SetActive ( false);
					na_zdi_D.transform.GetChild (1).gameObject.SetActive ( true);
					na_zdi_D.transform.GetChild (2).gameObject.SetActive ( false);
					na_zdi_D.transform.GetChild (3).gameObject.SetActive ( false);
						}
						else if (mistnost == "zed2") {
							mistnost = "zed4";
					na_zdi_D.transform.GetChild (0).gameObject.SetActive ( false);
					na_zdi_D.transform.GetChild (1).gameObject.SetActive (false);
					na_zdi_D.transform.GetChild (2).gameObject.SetActive (true);
					na_zdi_D.transform.GetChild (3).gameObject.SetActive (false);
						}
						else if (mistnost== "zed3") {
							mistnost = "zed1";
					na_zdi_D.transform.GetChild (0).gameObject.SetActive ( false);
					na_zdi_D.transform.GetChild (1).gameObject.SetActive (false);
					na_zdi_D.transform.GetChild (2).gameObject.SetActive (false);
					na_zdi_D.transform.GetChild (3).gameObject.SetActive ( false);
						}
						else if (mistnost == "zed4") {
							mistnost = "zed2";
					na_zdi_D.transform.GetChild (0).gameObject.SetActive ( true);
					na_zdi_D.transform.GetChild (1).gameObject.SetActive ( false);
					na_zdi_D.transform.GetChild (2).gameObject.SetActive (false);
					na_zdi_D.transform.GetChild (3).gameObject.SetActive( false);
						}
					}


			if (ze_zdi == "Z") {
				mistnost = "zed1";
				na_zdi_D.transform.GetChild (0).gameObject.SetActive ( false);
				na_zdi_D.transform.GetChild (1).gameObject.SetActive ( false);
				na_zdi_D.transform.GetChild (2).gameObject.SetActive (false);
				na_zdi_D.transform.GetChild (3).gameObject.SetActive( false);
			}*/
			/*
			if (ze_zdi == "Z") {
				if (mistnost == "zed1" || mistnost == "zed2" || mistnost == "zed4") {
					mistnost = "zem";
				} else if (mistnost == "zed3") {
					mistnost = "zem_zkouska";
					dira.SetActive (false);
				} else if (mistnost == "zem") {
					mistnost = "zed1";
				}
				}
*//*
			ze_zdi = "D";
		}





			if (other.CompareTag("strop")) {
			print("zedE");



			//ze_zdi = "S";
		}
			if (other.CompareTag("zem")) {
			print("zedF");

			ze_zdi = "Z";
		}
		*/
		print (mistnost);
	}


}
