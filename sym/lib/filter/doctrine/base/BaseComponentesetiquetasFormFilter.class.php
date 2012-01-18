<?php

/**
 * Componentesetiquetas filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseComponentesetiquetasFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'componentesetiquetas_font'           => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'componentesetiquetas_size'           => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'componentesetiquetas_bold'           => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'componentesetiquetas_italic'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'componentesetiquetas_yinicial'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'componentesetiquetas_xinicial'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'componentesetiquetas_yfinal'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'componentesetiquetas_variable'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'componentesetiquetas_tipo'           => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'componentesetiquetas_alignh'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'componentesetiquetas_alignv'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'componentesetiquetas_xfinal'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'componentesetiquetas_param'          => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'componentesetiquetas_numeroetiqueta' => new sfWidgetFormFilterInput(array('with_empty' => false)),
    ));

    $this->setValidators(array(
      'componentesetiquetas_font'           => new sfValidatorPass(array('required' => false)),
      'componentesetiquetas_size'           => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'componentesetiquetas_bold'           => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'componentesetiquetas_italic'         => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'componentesetiquetas_yinicial'       => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'componentesetiquetas_xinicial'       => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'componentesetiquetas_yfinal'         => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'componentesetiquetas_variable'       => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'componentesetiquetas_tipo'           => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'componentesetiquetas_alignh'         => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'componentesetiquetas_alignv'         => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'componentesetiquetas_xfinal'         => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'componentesetiquetas_param'          => new sfValidatorPass(array('required' => false)),
      'componentesetiquetas_numeroetiqueta' => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
    ));

    $this->widgetSchema->setNameFormat('componentesetiquetas_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Componentesetiquetas';
  }

  public function getFields()
  {
    return array(
      'componentesetiquetas_id'             => 'Number',
      'componentesetiquetas_font'           => 'Text',
      'componentesetiquetas_size'           => 'Number',
      'componentesetiquetas_bold'           => 'Number',
      'componentesetiquetas_italic'         => 'Number',
      'componentesetiquetas_yinicial'       => 'Number',
      'componentesetiquetas_xinicial'       => 'Number',
      'componentesetiquetas_yfinal'         => 'Number',
      'componentesetiquetas_variable'       => 'Number',
      'componentesetiquetas_tipo'           => 'Number',
      'componentesetiquetas_alignh'         => 'Number',
      'componentesetiquetas_alignv'         => 'Number',
      'componentesetiquetas_xfinal'         => 'Number',
      'componentesetiquetas_param'          => 'Text',
      'componentesetiquetas_numeroetiqueta' => 'Number',
    );
  }
}
