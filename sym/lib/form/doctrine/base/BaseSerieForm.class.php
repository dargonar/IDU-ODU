<?php

/**
 * Serie form base class.
 *
 * @method Serie getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseSerieForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'serie_id'      => new sfWidgetFormInputHidden(),
      'serie_tipo'    => new sfWidgetFormInputText(),
      'serie_numero'  => new sfWidgetFormInputText(),
      'serie_maximo'  => new sfWidgetFormInputText(),
      'serie_minimo'  => new sfWidgetFormInputText(),
      'serie_prefijo' => new sfWidgetFormInputText(),
      'serie_sufijo'  => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'serie_id'      => new sfValidatorChoice(array('choices' => array($this->getObject()->get('serie_id')), 'empty_value' => $this->getObject()->get('serie_id'), 'required' => false)),
      'serie_tipo'    => new sfValidatorString(array('max_length' => 1)),
      'serie_numero'  => new sfValidatorInteger(),
      'serie_maximo'  => new sfValidatorInteger(),
      'serie_minimo'  => new sfValidatorInteger(),
      'serie_prefijo' => new sfValidatorString(array('max_length' => 10, 'required' => false)),
      'serie_sufijo'  => new sfValidatorInteger(array('required' => false)),
    ));

    $this->widgetSchema->setNameFormat('serie[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Serie';
  }

}
