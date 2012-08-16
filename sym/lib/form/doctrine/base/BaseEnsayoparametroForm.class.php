<?php

/**
 * Ensayoparametro form base class.
 *
 * @method Ensayoparametro getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseEnsayoparametroForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'id'       => new sfWidgetFormInputHidden(),
      'tag'      => new sfWidgetFormInputText(),
      'paso'     => new sfWidgetFormInputText(),
      'valor'    => new sfWidgetFormInputText(),
      'ensayoid' => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Ensayo'), 'add_empty' => true)),
    ));

    $this->setValidators(array(
      'id'       => new sfValidatorChoice(array('choices' => array($this->getObject()->get('id')), 'empty_value' => $this->getObject()->get('id'), 'required' => false)),
      'tag'      => new sfValidatorString(array('max_length' => 128)),
      'paso'     => new sfValidatorInteger(),
      'valor'    => new sfValidatorNumber(),
      'ensayoid' => new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Ensayo'), 'required' => false)),
    ));

    $this->widgetSchema->setNameFormat('ensayoparametro[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Ensayoparametro';
  }

}
