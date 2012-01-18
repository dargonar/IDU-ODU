<?php

/**
 * Modelos filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseModelosFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'modelos_marca'        => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'modelos_modelo'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'modelos_codigo'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'modelos_referencia'   => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Caracteristicastecnicasequipos'), 'add_empty' => true)),
      'modelos_ean13'        => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'modelos_etiqueta'     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'modelos_etiquetacaja' => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'modelos_logo'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'modelos_conjunto'     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'modelos_capacidad'    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'modelos_codigoicsa'   => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'modelos_descripcion'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'modelos_dimensiones'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'modelos_esidu'        => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'es_activo'            => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'background_bulto'     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'background_producto'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
    ));

    $this->setValidators(array(
      'modelos_marca'        => new sfValidatorPass(array('required' => false)),
      'modelos_modelo'       => new sfValidatorPass(array('required' => false)),
      'modelos_codigo'       => new sfValidatorPass(array('required' => false)),
      'modelos_referencia'   => new sfValidatorDoctrineChoice(array('required' => false, 'model' => $this->getRelatedModelName('Caracteristicastecnicasequipos'), 'column' => 'caracteristicastecnicasequipos_id')),
      'modelos_ean13'        => new sfValidatorPass(array('required' => false)),
      'modelos_etiqueta'     => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'modelos_etiquetacaja' => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'modelos_logo'         => new sfValidatorPass(array('required' => false)),
      'modelos_conjunto'     => new sfValidatorPass(array('required' => false)),
      'modelos_capacidad'    => new sfValidatorPass(array('required' => false)),
      'modelos_codigoicsa'   => new sfValidatorPass(array('required' => false)),
      'modelos_descripcion'  => new sfValidatorPass(array('required' => false)),
      'modelos_dimensiones'  => new sfValidatorPass(array('required' => false)),
      'modelos_esidu'        => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'es_activo'            => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'background_bulto'     => new sfValidatorPass(array('required' => false)),
      'background_producto'  => new sfValidatorPass(array('required' => false)),
    ));

    $this->widgetSchema->setNameFormat('modelos_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Modelos';
  }

  public function getFields()
  {
    return array(
      'modelos_id'           => 'Number',
      'modelos_marca'        => 'Text',
      'modelos_modelo'       => 'Text',
      'modelos_codigo'       => 'Text',
      'modelos_referencia'   => 'ForeignKey',
      'modelos_ean13'        => 'Text',
      'modelos_etiqueta'     => 'Number',
      'modelos_etiquetacaja' => 'Number',
      'modelos_logo'         => 'Text',
      'modelos_conjunto'     => 'Text',
      'modelos_capacidad'    => 'Text',
      'modelos_codigoicsa'   => 'Text',
      'modelos_descripcion'  => 'Text',
      'modelos_dimensiones'  => 'Text',
      'modelos_esidu'        => 'Number',
      'es_activo'            => 'Number',
      'background_bulto'     => 'Text',
      'background_producto'  => 'Text',
    );
  }
}
