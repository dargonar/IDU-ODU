<?php

class CaracteristicastecnicasequiposQuery extends Doctrine_Query
{
  static public function create_new()
  {
    return new CaracteristicastecnicasequiposQuery();
  }
 
  public function getByNombre($nombre, $es_idu)
  {
    $q = Doctrine_Query::create();
    $q->from('Caracteristicastecnicasequipos c');
    $q->where('c.caracteristicastecnicasequipos_nombre = ?', $nombre );
    $q->andWhere('c.caracteristicastecnicasequipos_esidu = ?', $es_idu);
    return $q->fetchOne();
      
  }
  
  public function getById($id)
  {
    $q = Doctrine_Query::create();
    $q->from('Caracteristicastecnicasequipos c');
    $q->where('c.id = ?', $id );
    return $q->fetchOne();
      
  }

}