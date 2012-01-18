<?php

class UserProfileQuery extends Doctrine_Query
{
  static public function create_new()
  {
    return new UserProfileQuery();
  }
 
  public function setUserGroup($user_id, $group_id)
  {
    $q = Doctrine_Query::create()
    ->delete('sfGuardUserGroup gug')
    ->where('gug.user_id = ?', $user_id);
    //->andWhere('group_id = ?', $group_id);
    $rows = $q->execute();
    
    // $sfGuardUserGroup = new sfGuardUserGroup();
    // $sfGuardUserGroup->user_id  = $user_id;
    // $sfGuardUserGroup->group_id = $group_id;
    // $sfGuardUserGroup->save();
    
    $ug = new sfGuardUserGroup();
    $ug->setUser(Doctrine_Core::getTable('sfGuardUser')->findOneById($user_id));
    $ug->setGroup(Doctrine_Core::getTable('sfGuardGroup')->findOneById($group_id));

    $ug->save();
      
  }


}