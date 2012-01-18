<?php

/**
 * sfGuardUser form.
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrinePluginFormTemplate.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class sfGuardUserForm extends PluginsfGuardUserForm
{
  public function configure()
  {
      unset(
        $this['last_login'],
        $this['created_at'],
        $this['updated_at'],
        //$this['is_super_admin'],
        $this['permissions_list'],
        $this['salt'],
        $this['algorithm']
        //,$this['password']
      );
      
    $this->widgetSchema->setLabels( array(
      'first_name'    => 'Nombre',
      'last_name'     => 'Apellido',
      'email_address' => 'e-mail',
      'username'      => 'Usuario',
      'password'      => 'Contraseña',
      'is_active'     => 'Esta activo?',
      'is_super_admin'=> 'Es Super Admin',
      'groups_list'   => 'Permisos/Rol',
    ));
      
  }
  
}
