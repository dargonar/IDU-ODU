<?php

/**
 * Serie filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseSerieFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'serie_tipo'    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'serie_numero'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'serie_maximo'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'serie_minimo'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'serie_prefijo' => new sfWidgetFormFilterInput(),
      'serie_sufijo'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
    ));

    $this->setValidators(array(
      'serie_tipo'    => new sfValidatorPass(array('required' => false)),
      'serie_numero'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'serie_maximo'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'serie_minimo'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'serie_prefijo' => new sfValidatorPass(array('required' => false)),
      'serie_sufijo'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
    ));

    $this->widgetSchema->setNameFormat('serie_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Serie';
  }

  public function getFields()
  {
    return array(
      'serie_id'      => 'Number',
      'serie_tipo'    => 'Text',
      'serie_numero'  => 'Number',
      'serie_maximo'  => 'Number',
      'serie_minimo'  => 'Number',
      'serie_prefijo' => 'Text',
      'serie_sufijo'  => 'Number',
    );
  }
}
