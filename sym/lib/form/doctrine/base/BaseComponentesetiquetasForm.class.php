<?php

/**
 * Componentesetiquetas form base class.
 *
 * @method Componentesetiquetas getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseComponentesetiquetasForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'componentesetiquetas_id'             => new sfWidgetFormInputHidden(),
      'componentesetiquetas_font'           => new sfWidgetFormInputText(),
      'componentesetiquetas_size'           => new sfWidgetFormInputText(),
      'componentesetiquetas_bold'           => new sfWidgetFormInputText(),
      'componentesetiquetas_italic'         => new sfWidgetFormInputText(),
      'componentesetiquetas_yinicial'       => new sfWidgetFormInputText(),
      'componentesetiquetas_xinicial'       => new sfWidgetFormInputText(),
      'componentesetiquetas_yfinal'         => new sfWidgetFormInputText(),
      'componentesetiquetas_variable'       => new sfWidgetFormInputText(),
      'componentesetiquetas_tipo'           => new sfWidgetFormInputText(),
      'componentesetiquetas_alignh'         => new sfWidgetFormInputText(),
      'componentesetiquetas_alignv'         => new sfWidgetFormInputText(),
      'componentesetiquetas_xfinal'         => new sfWidgetFormInputText(),
      'componentesetiquetas_param'          => new sfWidgetFormInputText(),
      'componentesetiquetas_numeroetiqueta' => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'componentesetiquetas_id'             => new sfValidatorChoice(array('choices' => array($this->getObject()->get('componentesetiquetas_id')), 'empty_value' => $this->getObject()->get('componentesetiquetas_id'), 'required' => false)),
      'componentesetiquetas_font'           => new sfValidatorString(array('max_length' => 32, 'required' => false)),
      'componentesetiquetas_size'           => new sfValidatorNumber(array('required' => false)),
      'componentesetiquetas_bold'           => new sfValidatorInteger(array('required' => false)),
      'componentesetiquetas_italic'         => new sfValidatorInteger(array('required' => false)),
      'componentesetiquetas_yinicial'       => new sfValidatorNumber(array('required' => false)),
      'componentesetiquetas_xinicial'       => new sfValidatorNumber(array('required' => false)),
      'componentesetiquetas_yfinal'         => new sfValidatorNumber(array('required' => false)),
      'componentesetiquetas_variable'       => new sfValidatorInteger(array('required' => false)),
      'componentesetiquetas_tipo'           => new sfValidatorInteger(array('required' => false)),
      'componentesetiquetas_alignh'         => new sfValidatorInteger(array('required' => false)),
      'componentesetiquetas_alignv'         => new sfValidatorInteger(array('required' => false)),
      'componentesetiquetas_xfinal'         => new sfValidatorNumber(array('required' => false)),
      'componentesetiquetas_param'          => new sfValidatorString(array('max_length' => 100)),
      'componentesetiquetas_numeroetiqueta' => new sfValidatorInteger(),
    ));

    $this->widgetSchema->setNameFormat('componentesetiquetas[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Componentesetiquetas';
  }

}
