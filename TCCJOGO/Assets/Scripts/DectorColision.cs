
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectorColision : MonoBehaviour
{

   [SerializeField]
   private Transform pontoColisaoParedeEsquerda;

   [SerializeField]
   private Transform pontoColisaoParedeDireita;

   [SerializeField]
   private Vector2 areaColisao;

   [SerializeField]
   private LayerMask layerMaskColisao;

   private void OnDrawGizmos() {
    if (this.pontoColisaoParedeEsquerda != null){
      Gizmos.DrawWireCube(this.pontoColisaoParedeEsquerda.position, this.areaColisao);

   }
    if (this.pontoColisaoParedeDireita != null){
      Gizmos.DrawWireCube(this.pontoColisaoParedeDireita.position, this.areaColisao);
    }
   }

   public bool EstaColidindoParedeEsquerda(){
      return EstaColidindo(this.pontoColisaoParedeEsquerda.position);
   }

   public bool EstaColidindoParedeDireita(){
      return EstaColidindo(this.pontoColisaoParedeDireita.position);
   }

   private bool EstaColidindo(Vector2 posicaoDeteccaoColisao){
      Collider2D colisor = Physics2D.OverlapBox(posicaoDeteccaoColisao, this.areaColisao, 0, this.layerMaskColisao);
      if (colisor != null) 
      {
         Debug.Log("Encontrou collider: " + colisor.name); 
         return true;
      }
      return false;
   }
}
