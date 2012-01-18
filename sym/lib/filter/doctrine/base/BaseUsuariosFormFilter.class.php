<?php

/**
 * Usuarios filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseUsuariosFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'usuarios_password'    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'usuarios_descripcion' => new sfWidgetFormFilterInput(array('with_empty' => false)),
    ));

    $this->setValidators(array(
      'usuarios_password'    => new sfValidatorPass(array('required' => false)),
      'usuarios_descripcion' => new sfValidatorPass(array('required' => false)),
    ));

    $this->widgetSchema->setNameFormat('usuarios_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Usuarios';
  }

  public function getFields()
  {
    return array(
      'usuarios_id'          => 'Number',
      'usuarios_password'    => 'Text',
      'usuarios_descripcion' => 'Text',
    );
  }
}
