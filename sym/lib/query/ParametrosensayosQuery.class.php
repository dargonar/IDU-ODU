<?php

class ParametrosensayosQuery extends Doctrine_Query
{
  static public function create_new()
  {
    return new ParametrosensayosQuery();
  }
 
  public function getById($id, $es_idu)
  {
    
    $q = Doctrine_Query::create();
    
    if($es_idu==1)
    {
      $q->from('Parametrosensayosidu pi');
      $q->where('pi.parametrosensayosidu_id = ?', $id );
      return $q->fetchOne();
    }
    
    $q->from('Parametrosensayosodu po');
    $q->where('po.parametrosensayosodu_id = ?', $id );
    return $q->fetchOne();
      
  }


}