<?php

/**
 * Numeroserie filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseNumeroserieFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'tipo'    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'numero'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'maximo'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'minimo'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'prefijo' => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'sufijo'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
    ));

    $this->setValidators(array(
      'tipo'    => new sfValidatorPass(array('required' => false)),
      'numero'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'maximo'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'minimo'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'prefijo' => new sfValidatorPass(array('required' => false)),
      'sufijo'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
    ));

    $this->widgetSchema->setNameFormat('numeroserie_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Numeroserie';
  }

  public function getFields()
  {
    return array(
      'id'      => 'Number',
      'tipo'    => 'Text',
      'numero'  => 'Number',
      'maximo'  => 'Number',
      'minimo'  => 'Number',
      'prefijo' => 'Text',
      'sufijo'  => 'Number',
    );
  }
}
