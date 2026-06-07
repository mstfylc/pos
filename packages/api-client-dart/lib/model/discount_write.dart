//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/discount_type.dart';
import 'package:mansis_pos_api_client/model/discount_category.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'discount_write.g.dart';

abstract class DiscountWrite implements Built<DiscountWrite, DiscountWriteBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @nullable
    @BuiltValueField(wireName: r'description')
    String get description;

    @BuiltValueField(wireName: r'amount')
    double get amount;

    @BuiltValueField(wireName: r'maxDiscountAmount')
    double get maxDiscountAmount;

    @nullable
    @BuiltValueField(wireName: r'expireDate')
    DateTime get expireDate;

    @BuiltValueField(wireName: r'discountType')
    DiscountType get discountType;
    // enum discountTypeEnum {  Percentage,  Amount,  };

    @BuiltValueField(wireName: r'discountCategory')
    DiscountCategory get discountCategory;
    // enum discountCategoryEnum {  All,  Branch,  Personnel,  Pos,  };

    @BuiltValueField(wireName: r'sortOrder')
    int get sortOrder;

    DiscountWrite._();

    static void _initializeBuilder(DiscountWriteBuilder b) => b;

    factory DiscountWrite([void updates(DiscountWriteBuilder b)]) = _$DiscountWrite;

    @BuiltValueSerializer(custom: true)
    static Serializer<DiscountWrite> get serializer => _$DiscountWriteSerializer();
}

class _$DiscountWriteSerializer implements StructuredSerializer<DiscountWrite> {

    @override
    final Iterable<Type> types = const [DiscountWrite, _$DiscountWrite];
    @override
    final String wireName = r'DiscountWrite';

    @override
    Iterable<Object> serialize(Serializers serializers, DiscountWrite object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        if (object.description != null) {
            result
                ..add(r'description')
                ..add(serializers.serialize(object.description,
                    specifiedType: const FullType(String)));
        }
        result
            ..add(r'amount')
            ..add(serializers.serialize(object.amount,
                specifiedType: const FullType(double)));
        result
            ..add(r'maxDiscountAmount')
            ..add(serializers.serialize(object.maxDiscountAmount,
                specifiedType: const FullType(double)));
        if (object.expireDate != null) {
            result
                ..add(r'expireDate')
                ..add(serializers.serialize(object.expireDate,
                    specifiedType: const FullType(DateTime)));
        }
        result
            ..add(r'discountType')
            ..add(serializers.serialize(object.discountType,
                specifiedType: const FullType(DiscountType)));
        result
            ..add(r'discountCategory')
            ..add(serializers.serialize(object.discountCategory,
                specifiedType: const FullType(DiscountCategory)));
        result
            ..add(r'sortOrder')
            ..add(serializers.serialize(object.sortOrder,
                specifiedType: const FullType(int)));
        return result;
    }

    @override
    DiscountWrite deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = DiscountWriteBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'description':
                    result.description = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'amount':
                    result.amount = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'maxDiscountAmount':
                    result.maxDiscountAmount = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'expireDate':
                    result.expireDate = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'discountType':
                    result.discountType = serializers.deserialize(value,
                        specifiedType: const FullType(DiscountType)) as DiscountType;
                    break;
                case r'discountCategory':
                    result.discountCategory = serializers.deserialize(value,
                        specifiedType: const FullType(DiscountCategory)) as DiscountCategory;
                    break;
                case r'sortOrder':
                    result.sortOrder = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
            }
        }
        return result.build();
    }
}

