<?php

/**
 * UserProfile form.
 *
 * @package    newlife
 * @subpackage form
 * @author     wecodeyourapp
 * @version    SVN: $Id: sfDoctrineFormTemplate.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class BackendUserProfileForm extends BaseUserProfileForm
{
  public function configure()
  {
    unset(
     $this['sf_guard_user_id'],
     $this['created_at'],
     $this['updated_at']
    );
    
    $this->embedForm('sf_guard_user', new sfGuardUserForm($this->getObject()->getUser()) );
    
    $this->widgetSchema->setLabels( array(
      'numero_legajo'     => 'Nro. Legajo',
      'phone'             =>'Teléfono',
      'turno'             =>'Turno',
      'sf_guard_user'     => 'Usuario RunTest',
    ));
    
  }
}
