<?php

/**
 * Fallasodu filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseFallasoduFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'descripcion'   => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'prioridadalta' => new sfWidgetFormFilterInput(array('with_empty' => false)),
    ));

    $this->setValidators(array(
      'descripcion'   => new sfValidatorPass(array('required' => false)),
      'prioridadalta' => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
    ));

    $this->widgetSchema->setNameFormat('fallasodu_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Fallasodu';
  }

  public function getFields()
  {
    return array(
      'numerodefalla' => 'Number',
      'descripcion'   => 'Text',
      'prioridadalta' => 'Number',
    );
  }
}
