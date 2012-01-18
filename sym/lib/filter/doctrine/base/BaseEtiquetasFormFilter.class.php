<?php

/**
 * Etiquetas filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseEtiquetasFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'etiquetas_nombre' => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'etiquetas_esidu'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'es_activa'        => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'es_bulto'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
    ));

    $this->setValidators(array(
      'etiquetas_nombre' => new sfValidatorPass(array('required' => false)),
      'etiquetas_esidu'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'es_activa'        => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'es_bulto'         => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
    ));

    $this->widgetSchema->setNameFormat('etiquetas_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Etiquetas';
  }

  public function getFields()
  {
    return array(
      'etiquetas_id'     => 'Number',
      'etiquetas_nombre' => 'Text',
      'etiquetas_esidu'  => 'Number',
      'es_activa'        => 'Number',
      'es_bulto'         => 'Number',
    );
  }
}
